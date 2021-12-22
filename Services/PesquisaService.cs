﻿using RichTextBoxHTMLFormat;
using SearchInBases.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SearchInBases.Services
{
    public class PesquisaService
    {
        private string nomeArquivoResultado;

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
            bool ocorreuErroNaConsulta = false;
            Vars.isPesquisando = true;
            callbackStatusApp();
            try
            {
                Log.AddIniciandoPesquisa();
                List<Connection> conexoesHabilitadas = Vars.connections.FindAll(c => c.habilitado);
                tratarConexoesHabilitadas(callbackConsole, conexoesHabilitadas);

                nomeArquivoResultado = CsvService.CriarArquivo(sqlParams);
                ConnectionService.ExecutarSQL(callbackConsole, AdicionarResultadoCsv,  conexoesHabilitadas, sqlParams, ocorreuErroNaConsulta);

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
                Message.MessagemPesquisaFinalizada(ocorreuErroNaConsulta);
            }            
        }

        private void AdicionarResultadoCsv(string texto)
        {
            CsvService.Add(nomeArquivoResultado, texto);
        }

        private void AdicionarConsultaHistorico(SQLParams sqlParams)
        {            
            Vars.historico.consultas.Add(new DadosConsulta(sqlParams));
            HistoricoService.Save();
        }

        public void validarComandoSQL(SQLParams sqlParams)
        {
            if (String.IsNullOrWhiteSpace(sqlParams.GetSQL()))
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
