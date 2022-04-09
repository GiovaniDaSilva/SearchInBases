using MySqlConnector;
using SearchInBases.Enum;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

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
                using (StreamWriter sw = new StreamWriter(File.Open(arquivo, FileMode.Open), Encoding.UTF8))
                {
                    var sqlLine = sqlParams.sql.Replace(Environment.NewLine, " ");
                    sw.WriteLine(String.Format(padrao, data));
                    sw.WriteLine("SQL Excutado: " + sqlLine);
                    sw.WriteLine("Resultado Esperado: " + GetEnumDescription(Vars.resultadoEsperado));
                    sw.WriteLine("Ambiente: " + GetEnumDescription(sqlParams.filtro.ambiente));
                    sw.WriteLine("Bases: " + GetEnumDescription(sqlParams.filtro.statusBase));
                    sw.WriteLine(Environment.NewLine);
                }
                //File.AppendAllText(arquivo, String.Format(padrao, data) + Environment.NewLine);
                //File.AppendAllText(arquivo, "SQL Excutado: " + sqlParams.sql + Environment.NewLine);
                //File.AppendAllText(arquivo, "Resultado Esperado: " + GetEnumDescription(Vars.resultadoEsperado) + Environment.NewLine);
                //File.AppendAllText(arquivo, Environment.NewLine);
            }

            return arquivo;
        }

        public static string GetEnumDescription(object value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

    }
}
