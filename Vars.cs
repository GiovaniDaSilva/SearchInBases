using SearchInBases.Entity;
using SearchInBases.Services;
using System;
using System.Collections.Generic;

namespace SearchInBases
{
    public static class Vars
    {
        public static string appName = "Search In Bases";
        public static string appVersion = "1.0.0";
        public static string appNameWithVersion = Vars.appName + "  v." + Vars.appVersion;

        public static string pathApp = AppDomain.CurrentDomain.BaseDirectory;
        public static string pathResultados = AppDomain.CurrentDomain.BaseDirectory + @"Resultados\";
        public static string pathLog = AppDomain.CurrentDomain.BaseDirectory + "log.txt";        
        public static string nameFileConfig = "config.json";
        public static string nameFileLog = "log.txt";
        public static string nameFileResultado = "Resultado{0}.csv";
        
        public static bool somenteConsulta = true;
        public static bool isPesquisando;

        public static Config config = new Config();
        public static List<Connection> connections;

        public static string url_perfil_git = "https://github.com/GiovaniDaSilva";
        public static string url_projeto_git = url_perfil_git + "/SearchInBases";
    }

}
