using MySqlConnector;
using SearchInBases.Entity;
using SearchInBases.Enum;
using System;
using System.Collections.Generic;
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
        private static string padraoCsv = "Resultado da busca realizado em: {0}" + Environment.NewLine;
        private static string padraoSql = "Script gerado para a execução em: {0}" + Environment.NewLine;


        public static void Add(string arquivo, string line)
        {
            line = line + Environment.NewLine;
            File.AppendAllText(arquivo, line);
        }

        public static string CriarArquivoCSV(Entity.SQLParams sqlParams)
        {
            DateTime data = DateTime.Now;
            string arquivo = Vars.pathResultados + String.Format(Vars.nameFileResultadoCSV, Utils.FormatDateTimeToName(data));

            CriarDiretorio();
            if (!File.Exists(arquivo))
            {
                File.Create(arquivo).Close();
                using (StreamWriter sw = new StreamWriter(File.Open(arquivo, FileMode.Open), Encoding.UTF8))
                {
                    var sqlLine = sqlParams.sql.Replace(Environment.NewLine, " ");
                    sw.WriteLine(String.Format(padraoCsv, data));
                    DadosComuns(sqlParams, data, sw, sqlLine);
                    sw.WriteLine(Environment.NewLine);
                }
            }

            return arquivo;
        }

        private static void DadosComuns(SQLParams sqlParams, DateTime data, StreamWriter sw, string sqlLine, bool resultadoEsperado = true)
        {            
            sw.WriteLine("SQL Excutado: " + sqlLine);
            if(resultadoEsperado)  sw.WriteLine("Resultado Esperado: " + GetEnumDescription(Vars.resultadoEsperado));
            sw.WriteLine("Ambiente: " + GetEnumDescription(sqlParams.filtro.ambiente));
            sw.WriteLine("Bases: " + GetEnumDescription(sqlParams.filtro.statusBase));
        }

        public static string CriarArquivoSQL(Entity.SQLParams sqlParams)
        {
            DateTime data = DateTime.Now;
            string arquivo = Vars.pathResultados + String.Format(Vars.nameFileResultadoSQL, Utils.FormatDateTimeToName(data));

            CriarDiretorio();
            if (!File.Exists(arquivo))
            {
                File.Create(arquivo).Close();
                using (StreamWriter sw = new StreamWriter(File.Open(arquivo, FileMode.Open), Encoding.UTF8))
                {
                    var sqlLine = sqlParams.sql.Replace(Environment.NewLine, " ");
                    sw.WriteLine("/*");
                    sw.WriteLine(String.Format(padraoSql, data));
                    DadosComuns(sqlParams, data, sw, sqlLine, false);
                    sw.WriteLine("*/");
                    sw.WriteLine(Environment.NewLine);
                }
            }

            return arquivo;
        }

        private static void CriarDiretorio()
        {
            if (!Directory.Exists(Vars.pathResultados))
            {
                Directory.CreateDirectory(Vars.pathResultados);
            }
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

        public static void FinalizarArquivoCsv(string nomeArquivoResultado, List<BaseConsulta> listaConsultas, EResultado resultadoEsperado)
        {
            
            //Filtra conforme resultado esperado
            if (EResultado.ComOcorre.Equals(resultadoEsperado))
                listaConsultas.RemoveAll(b => !b.encontrouRegistro);
            else if (EResultado.SemOcorre.Equals(resultadoEsperado))
                listaConsultas.RemoveAll(b => b.encontrouRegistro);


            //Pega o header da base que encontrou registros
            string headerColumns = "DatabaseName;PossuiDados";
            bool encontrouDados = listaConsultas.Any(b => b.encontrouRegistro);            
            if (!EResultado.SemOcorre.Equals(resultadoEsperado) && encontrouDados)
                headerColumns = listaConsultas.Find(b => b.encontrouRegistro && !String.IsNullOrEmpty(b.headerColumns)).headerColumns;
            
            Add(nomeArquivoResultado, headerColumns);

            //Adiciona linhas consultadas no arquivo
            foreach(var consulta in listaConsultas.OrderBy(b => !b.encontrouRegistro))
            {
                consulta.resultadoConsulta.ForEach(r => Add(nomeArquivoResultado,r));
            }            
        }


        public static void FinalizarArquivoSql(string nomeArquivoResultado, List<BaseConsulta> listaConsultas)
        {
            //Adiciona linhas consultadas no arquivo
            foreach (var consulta in listaConsultas.OrderBy(b => b.databaseName))
            {
                consulta.resultadoConsulta.ForEach(r => {
                    Add(nomeArquivoResultado, $"/* INSTANCIA: {consulta.instance} BASE: {consulta.databaseName} */");
                    Add(nomeArquivoResultado, r);
                    Add(nomeArquivoResultado, Environment.NewLine);
                    });
            }
        }
    }
}
