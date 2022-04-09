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
        public static bool _controlPrintFieldsName;
        public static bool _ocorreuErroNaConsulta;

        public static void inicializarBasesAuth(Action<string> callbackConsole, Connection conn)
        {
            if (!Utils.IsNullOrEmpty(conn.basesAuth)) conn.basesAuth.Clear();

            try
            {
                using (var myConn = MySQLConnectorService.GetMySqlConnection(conn.mySqlConnector))
                {
                    myConn.Open();
                    using (var reader = MySQLConnectorService.ExecutarSQL(myConn, String.Format(SQLEnum.SQLAuth.select_instance, conn.baseAutenticador)))
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
                }
            }
            catch
            {
                var messagem = "Não foi possível buscar as bases a partir do autenticador da conexão (" + conn.connectionName + ")";
                callbackConsole(messagem);
                Log.addErroMessage(messagem);
                throw;
            }            
        }

        public static void ExecutarSQL(Action<string> callbackConsole,
                                        Action<string> callbackCsv,
                                        List<Connection> conexoesHabilitadas,
                                        SQLParams sqlParams)
        {
            
            _controlPrintFieldsName = false;
            Vars.basesUltimaConsulta.Clear();

            foreach (var conn in conexoesHabilitadas)
            {
                List<Task> threadsProcessando = new List<Task>();
                List<MySqlConnection> threadsConn = new List<MySqlConnection>();
                try
                {
                    int qtdMaxThreads = 20;
                    int countThread = 0;
                    foreach (var baseAuth in filtrarBasesAuth(conn.basesAuth, sqlParams))
                    {                                    
                        if(countThread < qtdMaxThreads)
                        {
                            if (Vars.pararPesquisa) break;
                            ExecutarTaskAsync(callbackConsole, callbackCsv, CallbackBaseExecutada, sqlParams, conn, threadsProcessando, threadsConn, baseAuth);
                            countThread++;
                        }
                        else
                        {
                            countThread = AguardandoLiberarThread(conn, threadsProcessando, qtdMaxThreads, countThread);
                            ExecutarTaskAsync(callbackConsole, callbackCsv, CallbackBaseExecutada, sqlParams, conn, threadsProcessando, threadsConn, baseAuth);
                            countThread++;
                        }
                    }   
                                        
                    AguardaProcessamentoThreads(conn, threadsProcessando);                   
                }
                finally
                {
                    // Garante que todas as conexões sejam fechadas
                    FecharThreadsConn(threadsConn);
                }

                MySqlConnection.ClearAllPools();
            }
            
        }

        private static void CallbackBaseExecutada(BaseUltimaConsulta baseUltimaConsulta)
        {
            Vars.basesUltimaConsulta.Add(baseUltimaConsulta);
        }
        private static int AguardandoLiberarThread(Connection conn, List<Task> threadsProcessando, int qtdMaxThreads, int countThread)
        {
            DateTime data = DateTime.Now;
            while (countThread >= qtdMaxThreads)
            {
                if (data.Second != DateTime.Now.Second)
                {
                    Debug.Print("Aguardando liberar thread na conexão " + conn.connectionName);
                    int countThreadCompleted = threadsProcessando.FindAll(t => t.IsCompleted).Count;
                    if (countThreadCompleted > 0)
                        countThread -= countThreadCompleted;

                    data = DateTime.Now;
                }
            }

            threadsProcessando.RemoveAll(t => t.IsCompleted);
            return countThread;
        }

        private static void ExecutarTaskAsync(Action<string> callbackConsole, Action<string> callbackCsv, Action<BaseUltimaConsulta> callbackBaseExecutada, SQLParams sqlParams, Connection conn, List<Task> threadsProcessando, List<MySqlConnection> threadsConn, BaseAuth baseAuth)
        {
            Task task = Task.Run(() =>
            {
                ExecutarSQLThread(callbackConsole, sqlParams, callbackCsv, callbackBaseExecutada, conn, threadsConn, baseAuth);
            });

            threadsProcessando.Add(task);
        }



        private static void ExecutarSQLThread(Action<string> callbackConsole,
                                              SQLParams sqlParams,
                                              Action<string> callbackCsv,
                                              Action<BaseUltimaConsulta> callbackBaseExecutada,
                                              Connection conn,
                                              List<MySqlConnection> threadsConn,
                                              BaseAuth baseAuth)
        {
            try
            {

                bool temRegistro = false;

                // Gera uma connection para cada thread
                using (var threadConn = MySQLConnectorService.GetMySqlConnection(conn.mySqlConnector))
                {
                 
                    threadsConn.Add(threadConn);
                    threadConn.Open();

                    try
                    {
                        threadConn.ChangeDatabase(baseAuth.databaseName);
                    }
                    catch
                    {
                        callbackConsole(ComumCallbackConsole(conn.connectionName, baseAuth.databaseName) + " -> " + RichFormatting.FontColor(database_notfound, Color.Red));
                        // Database not found
                        Log.addWarnMessage("Base (" + baseAuth.databaseName + ") não encontrado na conexão (" + conn.connectionName + ")");
                        return;
                    }


                    // Executa o comando e salva o retorno no CSV
                    using (var reader = MySQLConnectorService.ExecutarSQL(threadConn, sqlParams))
                    {        
                        temRegistro = reader.HasRows;
                        EResultado resultadoEsperado = Vars.resultadoEsperado;

                        callbackConsole(ComumCallbackConsole(conn.connectionName, baseAuth.databaseName) +
                            (temRegistro ? RichFormatting.FontColor(encontrou_ocorrencias, Color.DarkGreen) : RichFormatting.FontColor(nao_encontrou_ocorrencias, Color.DarkViolet)));
                     

                        if (!EResultado.SemOcorre.Equals(resultadoEsperado)) //com ocorre ou ambos
                        {
                            if (temRegistro)                            
                                PrintFieldsNameCsv(callbackCsv, reader, true);                            

                            if (temRegistro)
                            {
                                while (reader.Read())                            
                                    callbackCsv(FieldsReaderToCsv(baseAuth.databaseName, reader));    
                                
                            }else if(EResultado.Ambos.Equals(resultadoEsperado))
                                callbackCsv(FieldsSemOcorreToCsv(baseAuth));

                        }
                        else if(!temRegistro) // somentes sem ocorrencia
                        {
                            PrintFieldsNameCsv(callbackCsv, reader, false);
                            callbackCsv(FieldsSemOcorreToCsv(baseAuth));
                        }
                    }

                    threadConn.Close();

                    BaseUltimaConsulta baseUltimaConsulta = new BaseUltimaConsulta(baseAuth.instance, baseAuth.databaseName, temRegistro);
                    callbackBaseExecutada(baseUltimaConsulta);
                }

            }
            catch (Exception ex)
            {
                _ocorreuErroNaConsulta = true;
                callbackConsole(ComumCallbackConsole(conn.connectionName, baseAuth.databaseName) + " -> " + RichFormatting.FontColor(erro_executar_sql, Color.Red));
                Log.addErroMessage("Não foi possível executar o comenado SQL na base (" + baseAuth.databaseName + ") da conexão (" + conn.connectionName + ")");
                ErroService.TratarErro(ex);
                return;
            }
        }

        private static void PrintFieldsNameCsv(Action<string> callbackCsv, MySqlDataReader reader, bool comFieldsReader)
        {
            if (!_controlPrintFieldsName)
            {
                _controlPrintFieldsName = true;
                if(comFieldsReader)
                    callbackCsv(FieldsNameReaderToCsv(reader));
                else
                    callbackCsv(FieldsNameSemOcorreToCsv());
            }
        }

        private static string FieldsSemOcorreToCsv(BaseAuth baseAuth)
        {
            return $"{baseAuth.databaseName};Não";
        }

        private static string FieldsNameSemOcorreToCsv()
        {
            return "DatabaseName;PossuiDados";
        }

        private static string ComumCallbackConsole(string connName, string baseName)
        {
            return RichFormatting.FontColor(connName, Color.DarkMagenta) + RichFormatting.Negrito(" -> ") +
                                        RichFormatting.FontColor(baseName, Color.DarkBlue) + RichFormatting.Negrito(" -> ");
        }

        private static string FieldsNameReaderToCsv(MySqlDataReader reader)
        {
            string lineResult = "DatabaseName;PossuiDados";

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

            //PossuiResultado
            lineResult += ";Sim";

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


            //Bases filtradas
            if(sqlParams.basesFiltradas.Count > 0)
            {
                result.RemoveAll(b => !sqlParams.basesFiltradas.Contains(b.databaseName) &&
                                    !sqlParams.basesFiltradas.Contains(b.instance));
            }

            return result;
        }


        public static bool ExecutarTesteSQL(Action<string> callbackConsole,
                                              SQLParams sqlParams,                                                                                          
                                              Connection conn,                                              
                                              BaseAuth baseAuth)
        {            
            try
            {                
                using (var threadConn = MySQLConnectorService.GetMySqlConnection(conn.mySqlConnector))
                {
                    threadConn.Open();                    
                    threadConn.ChangeDatabase(baseAuth.databaseName);                                        
                    MySQLConnectorService.ExecutarSQL(threadConn, sqlParams);
                    threadConn.Close();
                }               
            }
            catch (Exception ex)
            {
                callbackConsole(ComumCallbackConsole(conn.connectionName, baseAuth.databaseName) + " -> " + ex.Message.ToString());                
                return false;
            }
            return true;
        }
    }
}
