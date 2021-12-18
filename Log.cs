using System;
using System.IO;

namespace SearchInBases
{
    public static class Log
    {

        private static string arquivo = Path.Combine(Vars.pathApp, Vars.nameFileLog);        
        private static string padrao = "Data: {0} - Tipo: {1} -> {2}" + Environment.NewLine;
        private static string erro = "ERRO";
        private static string warn = "WARNING";
        private static string info = "INFO";
        private static string msg = "MENSAGEM";
        
        private static string iniciando_pesquisa = "Iniciando pesquisa..";
        private static string pesquisa_finalizada = "Pesquisa finalizada.";


        // Logs fixos

        public static void AddIniciandoPesquisa()
        {
            Add(info, iniciando_pesquisa);
        }

        public static void AddPesquisaFinalizada()
        {
            Add(info, pesquisa_finalizada);
        }
        
        
        // Logs Tipados

        public static void addErroMessage(string message)
        {
            Add(erro , message);
        }

        public static void addWarnMessage(string message)
        {
            Add(warn, message);
        }

        public static void AddMessage(string message)
        {
            Add(msg , message);
        }

        public static void Add(string message)
        {
            Add(info, message);
        }


        private static void Add(string tipo,  string message)
        {
            CriarArquivoSeNaoExiste();
            string log = String.Format(padrao, DateTime.Now, tipo, message);
            File.AppendAllText(arquivo, log);
        }

        private static void CriarArquivoSeNaoExiste()
        {            
            if (!File.Exists(arquivo))
            {
                File.Create(arquivo).Close();
            }            
        }
    }



    internal class DadosLog
    {
        public DadosLog(string message)
        {
            this.dateTime = DateTime.Now;
            this.message = message;
        }

        public DateTime dateTime { get; set; }
        public string message { get; set; }

    }


}
