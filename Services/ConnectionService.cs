using MySqlConnector;
using RichTextBoxHTMLFormat;
using SearchInBases.Entity;
using SearchInBases.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

namespace SearchInBases.Services
{
    public static class ConnectionService
    {

        private static string encontrou_ocorrencias = "Encontrou ocorrências";
        private static string nao_encontrou_ocorrencias = "Não encontrou ocorrências";
        private static string erro_executar_sql = "Ocorreu um erro ao executar o comando SQL";
        private static string database_notfound = "Base de dados não localizada";
        public static bool _controlPrintFieldsName = false;
        public static bool _ocorreuErroNaConsulta = false;

        #region "Publicos"

        public static void inicializarBasesAuth(Action<string> callbackConsole, Connection conn)
        {
            if(!Utils.IsNullOrEmpty(conn.basesAuth)) conn.basesAuth.Clear();
            
            try
            {
                conn.connection.Open();

                using (var reader = MySQLConnectorService.ExecutarSQL(conn.connection, String.Format(SQLEnum.SQLAuth.select_instance, conn.baseAutenticador)))
                {
                    while (reader.Read())
                    {
                        if (Utils.IsNull(conn.basesAuth)) conn.basesAuth = new();

                        BaseAuth baseAuth = new BaseAuth(reader.GetString((int)SQLEnum.SQLAuthInstance.ID),
                            reader.GetString((int)SQLEnum.SQLAuthInstance.DATABASE_NAME),
                            reader.GetBoolean((int)SQLEnum.SQLAuthInstance.INTERNAL),
                            reader.GetBoolean((int)SQLEnum.SQLAuthInstance.ACTIVE));

                        conn.basesAuth.Add(baseAuth);
                    }
                }
            }catch 
            {
                _ocorreuErroNaConsulta = true;
                var messagem = "Não foi possível buscar as bases a partir do autenticador da conexão (" + conn.connectionName + ")";
                callbackConsole(messagem);
                Log.addErroMessage(messagem);
                throw;
            }
            finally
            {
               conn.connection.Close();
            }            
        }

        public  static void ExecutarSQL(Action<string> callback, List<Connection> conexoesHabilitadas, SQLParams sqlParams, bool ocorreuErroNaConsulta)
        {
            string nomeArquivoResultado = CsvService.CriarArquivo(sqlParams);
                       
            foreach (var conn in conexoesHabilitadas)
            {
                List<Task> threadsProcessando = new List<Task>();                
                List<MySqlConnection> threadsConn = new List<MySqlConnection>();

                try
                {
                    foreach (var baseAuth in filtrarBasesAuth(conn.basesAuth, sqlParams))
                    {
                        threadsProcessando.Add(Task.Run(() => {
                            ExecutarSQLThread(callback, sqlParams, nomeArquivoResultado, conn, threadsConn, baseAuth);
                        }));
                    }

                    //Aguarda a conclusão das threads de cada conexão
                    AguardaProcessamentoThreads(conn, threadsProcessando);

                }
                finally
                {
                    // Garante que todas as conexões sejam fechadas
                    FecharThreadsConn(threadsConn);
                }
            }

            ocorreuErroNaConsulta = _ocorreuErroNaConsulta;
            callback("Para acessar o resultado clique " +  RichFormatting.Link("aqui", nomeArquivoResultado));
        }

        #endregion


        #region "Privados"
        
        private static void ExecutarSQLThread(Action<string> callbackConsole, SQLParams sqlParams, string nomeArquivoResultado, Connection conn, List<MySqlConnection> threadsConn, BaseAuth baseAuth)
        {
            // Gera uma connection para cada thread
            var threadConn = MySQLConnectorService.GetMySqlConnection(conn.mySqlConnector);
            threadsConn.Add(threadConn);

            threadConn.Open();
            try
            {
                try
                {
                    threadConn.ChangeDatabase(baseAuth.databaseName);
                }
                catch
                {                    
                    callbackConsole(RichFormatting.FontColor(baseAuth.databaseName, Color.DarkBlue) + " -> " + RichFormatting.FontColor(database_notfound, Color.Red));
                    // Database not found
                    Log.addWarnMessage("Base (" + baseAuth.databaseName + ") não encontrado na conexão (" + conn.connectionName + ")");
                    return;
                }

                try
                {
                    // Executa o comando e salva o retorno no CSV
                    using (var reader = MySQLConnectorService.ExecutarSQL(threadConn, sqlParams))
                    {
                        callbackConsole(RichFormatting.FontColor(baseAuth.databaseName, Color.DarkBlue) + RichFormatting.Negrito(" -> ") + (reader.HasRows ? RichFormatting.FontColor(encontrou_ocorrencias, Color.DarkGreen) : RichFormatting.FontColor(nao_encontrou_ocorrencias, Color.DarkViolet)));

                        if (reader.HasRows && !_controlPrintFieldsName)
                        {
                            _controlPrintFieldsName = true;
                            CsvService.Add(nomeArquivoResultado, FieldsNameReaderToCsv(reader));
                        }
                        
                        while (reader.Read())
                        {
                            CsvService.Add(nomeArquivoResultado, FieldsReaderToCsv(baseAuth.databaseName, reader));
                        }
                    }

                }
                catch (Exception ex)
                {
                    _ocorreuErroNaConsulta = true;
                    callbackConsole(RichFormatting.FontColor(baseAuth.databaseName, Color.DarkBlue) + " -> " + RichFormatting.FontColor(erro_executar_sql, Color.Red));
                    Log.addErroMessage("Não foi possível executar o comenado SQL na base (" + baseAuth.databaseName + ") da conexão (" + conn.connectionName + ")");
                    ErroService.TratarErro(ex);
                    return;
                }
            }
            finally
            {
                threadConn.Close();
            }
        }

        private static string FieldsNameReaderToCsv(MySqlDataReader reader)
        {
            string lineResult = "DatabaseName";

            for (int i = 0; i < reader.FieldCount; i++)
            {
                lineResult += ";" + reader.GetName(i).ToString();
            }

            return lineResult;
        }

        private static void AguardaProcessamentoThreads(Connection conn, List<Task> threadsProcessando)
        {
            DateTime data = DateTime.Now;
            while (!threadsProcessando.TrueForAll(t => t.IsCompleted))
            {
                if (data.Second != DateTime.Now.Second)
                {
                    Debug.Print("Aguardando processamento das threads da " + conn.connectionName);
                    data = DateTime.Now;
                }
            }
        }

        private static void FecharThreadsConn(List<MySqlConnection> threadsConn)
        {
            foreach (var threadConn in threadsConn)
            {
                if (!ConnectionState.Closed.Equals(threadConn.State))
                    threadConn.Close();
            }
        }


        private static string FieldsReaderToCsv(string databaseName, MySqlConnector.MySqlDataReader reader)
        {
            string lineResult = databaseName;

            for (int i = 0; i < reader.FieldCount; i++)
            {
                lineResult += ";" + reader.GetValue(i).ToString();
            }

            return lineResult;
        }

        private static List<BaseAuth> filtrarBasesAuth(List<BaseAuth> basesAuth, SQLParams sqlParams)
        {
            var result = new List<BaseAuth>();
            result.AddRange(basesAuth);

            //Status
            if (SQLFiltro.enuStatusBase.Ativa.Equals(sqlParams.filtro.statusBase))
                result.RemoveAll(b => !b.ativo);

            else if (SQLFiltro.enuStatusBase.Inativa.Equals(sqlParams.filtro.statusBase))
                result.RemoveAll(b => b.ativo);


            // Ambiente
            if (SQLFiltro.enuAmbiente.Interno.Equals(sqlParams.filtro.ambiente))            
                result.RemoveAll(b => !b.interno);

            else if (SQLFiltro.enuAmbiente.Producao.Equals(sqlParams.filtro.ambiente))
                result.RemoveAll(b => b.interno);


            return result;
        }
        #endregion
    }
}
