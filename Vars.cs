using SearchInBases.Entity;
using SearchInBases.Services;
using System;
using System.Collections.Generic;

namespace SearchInBases
{
    public static class Vars
    {
        public static string pathApp = AppDomain.CurrentDomain.BaseDirectory;
        public static string pathResultados = AppDomain.CurrentDomain.BaseDirectory + @"Resultados\";
        public static string appName = "Search In Bases";
        public static string nameFileConfig = "config.json";
        public static string nameFileLog = "log.txt";
        public static string nameFileResultado = "Resultado{0}.csv";
        
        public static bool somenteConsulta = true;


        public static Config config = new Config();

        public static List<Connection> connections;

        public static bool isPesquisando;
    }

}
