using Newtonsoft.Json;
using SearchInBases.Entity;
using System.Collections.Generic;
using System.IO;

namespace SearchInBases.Services
{
    public class Config
    {
        public List<ConfigConn> configConn;

        
        public class ConfigConn
        {
            public string connName = "localhost";
            public string baseAuth = "";
            public string server = "";
            public string user = "";
            public string password = "";
        }

        internal List<Connection> getConnections()
        {            
            List<Connection> conns = new List<Connection>();

            if (configConn is null) return conns;

            foreach(var conn in configConn)
            {
                conns.Add(new Connection(conn.connName,
                                        conn.baseAuth,
                                        conn.server,
                                        conn.user,
                                        conn.password));
            }

            return conns;
        }

        public static string GetConfigFile()
        {
            return Vars.pathConfig;
        }

        public static Config Load()
        {
            Config config = new Config();

            var path = GetConfigFile();
            
            if (File.Exists(path))
            {
                var data = File.ReadAllText(path);
                config = JsonConvert.DeserializeObject<Config>(data);                        
            }

            if (config.configConn == null)
            {
                config.configConn = new();
                config.configConn.Add(new ConfigConn());
                config.Save();
            }

            return config;
        }

        public void Save()
        {
            var path = GetConfigFile();
            var data = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, data);
        }
    }
}
