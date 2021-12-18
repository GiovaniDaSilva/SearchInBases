using SearchInBases.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
                              SQLParams sqlParams)
        {
            Vars.isPesquisando = true;
            callbackStatusApp();
            try
            {
                Log.AddIniciandoPesquisa();
                List<Connection> conexoesHabilitadas = Vars.connections.FindAll(c => c.habilitado);
                tratarConexoesHabilitadas(conexoesHabilitadas);
                ConnectionService.ExecutarSQL(callbackConsole, conexoesHabilitadas, sqlParams);
            }
            catch(Exception ex)
            {
                ErroService.TratarErro(ex);
            }
            finally
            {
                Vars.isPesquisando = false;                
                Log.AddPesquisaFinalizada();
                callbackStatusApp();
                Message.InfoPesquisaFinalizada();
            }            
        }

        public void validarComandoSQL(SQLParams sqlParams)
        {           
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

        #endregion



        #region "Privados"

        
        // Privados
        private static void tratarConexoesHabilitadas(List<Connection> conexoesHabilitadas)
        {
            foreach (var conn in conexoesHabilitadas)
            {             
                if (Utils.IsNullOrEmpty(conn.basesAuth))
                {
                    ConnectionService.inicializarBasesAuth(conn);
                }                
            }
        }

        #endregion

    }
}
