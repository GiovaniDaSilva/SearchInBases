using RichTextBoxHTMLFormat;
using SearchInBases.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace SearchInBases.Services
{
    public class PesquisaService
    {        

        #region "Publicos"        
        public void AbrirJsonConfig()
        {
            var file = Config.GetConfigFile();
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(file)
            {
                UseShellExecute = true
            };
            p.Start();                       
        }

        public void Pesquisar(Action<string> callbackConsole,
                              Action callbackStatusApp, 
                              SQLParams sqlParams,
                              Action<BaseConsulta> callbackCsv,
                              string nomeArquivoResultado,
                              Action callbackFinalizarBusca
                              )
        {
            DateTime dtInicio = DateTime.Now;
            bool ocorreuErroNaConsulta = false;
            Vars.isPesquisando = true;
            callbackStatusApp();
            try
            {
                Log.AddIniciandoPesquisa();
                List<Connection> conexoesHabilitadas = Vars.connections.FindAll(c => c.habilitado);
                tratarConexoesHabilitadas(callbackConsole, conexoesHabilitadas);

                
                ConnectionService.ExecutarSQL(callbackConsole, callbackCsv,  conexoesHabilitadas, sqlParams);

                callbackFinalizarBusca();

                if (Vars.pararPesquisa)
                {
                    string msg = "Pesquisa interrompida";
                    callbackConsole(RichFormatting.FontColor(msg, Color.Red));
                    Log.addWarnMessage(msg);
                }

                Log.AddMessage("Arquivo com resultado: " + nomeArquivoResultado);
                callbackConsole("Para acessar o resultado clique " + RichFormatting.Link("aqui", nomeArquivoResultado));
            }
            catch(Exception ex)
            {
                ocorreuErroNaConsulta = true;
                ErroService.TratarErro(ex);
            }
            finally
            {
                Vars.isPesquisando = false;                
                Log.AddPesquisaFinalizada();
                AdicionarConsultaHistorico(sqlParams);
                callbackStatusApp();
                Message.MessagemPesquisaFinalizada(ocorreuErroNaConsulta, dtInicio);
            }            
        }

        public void GerarScript(Action<string> callbackConsole,
                             Action callbackStatusApp,
                             SQLParams sqlParams,
                             Action<BaseConsulta> callbackSql,
                             string nomeArquivoResultado,
                             Action callbackFinalizarScript
                             )
        {
            DateTime dtInicio = DateTime.Now;
            bool ocorreuErroNaConsulta = false;
            Vars.isPesquisando = true;
            callbackStatusApp();
            try
            {
                Log.AddIniciandoScript();
                List<Connection> conexoesHabilitadas = Vars.connections.FindAll(c => c.habilitado);
                tratarConexoesHabilitadas(callbackConsole, conexoesHabilitadas);

                foreach (var conn in conexoesHabilitadas)
                {                                      
                    foreach (var baseAuth in SQLService.filtrarBasesAuth(conn.basesAuth, sqlParams))
                    {
                        string script = sqlParams.sqlDescript.Replace(" %b.", $" {baseAuth.databaseName}.") + ";";

                        List<string> resultado = new List<string>();
                        resultado.Add(script);

                        BaseUltimaConsulta baseUltimaConsulta = new BaseUltimaConsulta(baseAuth.instance, baseAuth.databaseName, true);                        
                        BaseConsulta baseConsulta = new BaseConsulta(baseUltimaConsulta, "", resultado);
                        callbackSql(baseConsulta);

                        callbackConsole(RichFormatting.FontColor(conn.connectionName, Color.DarkMagenta) + RichFormatting.Negrito(" -> ") +
                                     RichFormatting.FontColor(baseAuth.databaseName, Color.DarkBlue) + RichFormatting.Negrito(" -> ") + " Processado");
                    }
                }


                callbackFinalizarScript();  
                Log.AddMessage("Arquivo de script: " + nomeArquivoResultado);
                callbackConsole("Para acessar o script clique " + RichFormatting.Link("aqui", nomeArquivoResultado));
            }
            catch (Exception ex)
            {
                ocorreuErroNaConsulta = true;
                ErroService.TratarErro(ex);
            }
            finally
            {
                Vars.isPesquisando = false;
                Log.AddScriptFinalizada();
                AdicionarConsultaHistorico(sqlParams);
                callbackStatusApp();
                Message.MessagemPesquisaFinalizada(ocorreuErroNaConsulta, dtInicio, true);
            }
        }

        private void AdicionarConsultaHistorico(SQLParams sqlParams)
        {            
            Vars.historico.consultas.Add(new DadosConsulta(sqlParams));
            HistoricoService.Save();
        }

        public void ValidarComandoSQL(SQLParams sqlParams)
        {
            if (String.IsNullOrWhiteSpace(sqlParams.sql))
            {
                string messagem = "Informe um comando SQL válido.";
                throw new Message.MessageException(messagem);
            }

            if (!SQLService.permitirExecutarComando(sqlParams))
            {
                string messagem = "Você não possui permissão para executar esse comando.";
                throw new Message.MessageException(messagem);
            }

            if (!SQLService.SQLValido(sqlParams))
            {
                string messagem = "Este não é um comando Select válido.";
                throw new Message.MessageException(messagem);
            }
        }

        public bool TestarSQL(Action<string> callbackConsole, Action callbackStatusApp, SQLParams sqlParams)
        {
            Vars.isPesquisando = true;
            callbackStatusApp();

            bool sucesso = true;
            try
            {
                Log.AddMessage("Testando comando SQL...");

                List<Connection> conexoesHabilitadas = Vars.connections.FindAll(c => c.habilitado);
                tratarConexoesHabilitadas(callbackConsole, conexoesHabilitadas);

                sucesso = ConnectionService.ExecutarTesteSQL(callbackConsole, sqlParams, conexoesHabilitadas[0], conexoesHabilitadas[0].basesAuth[0]);

            }
            catch (Exception ex)
            {                
                ErroService.TratarErro(ex);
            }
            finally
            {
                if (!sucesso)
                {
                    Vars.isPesquisando = false;                
                    callbackStatusApp();
                }

                Log.AddMessage("Comando SQL " + (sucesso ? "válido" : "inválido")); ;
            }

            return sucesso;
        }

        #endregion



        #region "Privados"


        // Privados
        private static void tratarConexoesHabilitadas(Action<string> callbackConsole, List<Connection> conexoesHabilitadas)
        {
            foreach (var conn in conexoesHabilitadas)
            {             
                if (Utils.IsNullOrEmpty(conn.basesAuth))
                {
                    ConnectionService.inicializarBasesAuth(callbackConsole, conn);
                }                
            }
        }

        #endregion

    }
}
