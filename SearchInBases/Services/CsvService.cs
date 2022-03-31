using System;
using System.IO;

namespace SearchInBases
{
    public static class CsvService
    {
        //private static string arquivo = Path.Combine(Vars.pathApp, Vars.nameFileLog);
        private static string padrao = "Resultado da busca realizado em: {0}" + Environment.NewLine;


        public static void Add(string arquivo, string line)
        {
            line = line + Environment.NewLine;
            File.AppendAllText(arquivo, line);
        }

        public static string CriarArquivo(Entity.SQLParams sqlParams)
        {
            DateTime data = DateTime.Now;
            string arquivo = Vars.pathResultados + String.Format(Vars.nameFileResultado, Utils.FormatDateTimeToName(data));

            if (!Directory.Exists(Vars.pathResultados))
            {
                Directory.CreateDirectory(Vars.pathResultados);
            }

            if (!File.Exists(arquivo))
            {
                File.Create(arquivo).Close();                
                File.AppendAllText(arquivo, String.Format(padrao, data) + Environment.NewLine);
                File.AppendAllText(arquivo, "SQL Excutado: " + sqlParams.sql + Environment.NewLine);
                File.AppendAllText(arquivo, Environment.NewLine);
            }

            return arquivo;
        }

    }
}
