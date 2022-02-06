using SearchInBases.Entity;
using SearchInBases.Services;
using System;
using System.Collections.Generic;

namespace SearchInBases
{
    public static class Vars
    {    
        //App
        public static string appName = "SearchInBases";        
        public static string appVersion = "1.0.7";
        public static string appNameWithVersion = Vars.appName + "  v." + Vars.appVersion;
        public static string pathApp = AppDomain.CurrentDomain.BaseDirectory;

        public static List<Connection> connections;
        public static bool somenteConsulta = true;
        public static bool isPesquisando;

        //Log
        public static string nameFileLog = "log.txt";
        public static string pathLog = AppDomain.CurrentDomain.BaseDirectory + nameFileLog;

        //Resultados
        public static string nameFileResultado = "Resultado{0}.csv";
        public static string pathResultados = AppDomain.CurrentDomain.BaseDirectory + @"Resultados\";

        //Config
        public static Config config = new Config();
        public static string nameFileConfig = "config.json";
        public static string pathConfig = AppDomain.CurrentDomain.BaseDirectory + nameFileConfig;

        //Historico
        public static Historico historico;
        public static string nameFileHistorico = "historico.json";        
        public static string pathHistorico = AppDomain.CurrentDomain.BaseDirectory + nameFileHistorico;

        //Git
        public static string url_perfil_git = "https://github.com/GiovaniDaSilva";
        public static string url_projeto_git = url_perfil_git + "/SearchInBases";


        //Filter
        public static List<string> basesFiltradas { get; set; } = new List<string>();


        public static void AtualizarConnections()
        {
            connections = config.ToConnections();
        }
    }

}
