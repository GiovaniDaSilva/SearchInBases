using MySqlConnector;
using SearchInBases.Services;
using System.Collections.Generic;

namespace SearchInBases.Entity
{
    public class Connection
    {
        public string connectionName { get; set; }
        public string baseAutenticador { get; set; }
        public MySQLConnector mySqlConnector { get; set; }        
        public bool habilitado { get; set; }
        public List<BaseAuth> basesAuth { get; set; }


        public Connection(string conName, string server, string user, string password)
        {
            this.mySqlConnector = new MySQLConnector(server, user, password);           
            this.connectionName = conName;
            this.baseAutenticador = getBaseAutenticador(server);
            this.habilitado = false;            
        }

        private string getBaseAutenticador(string server)
        {
            if (server.ToLower().Contains("alpha")){
                return "alpha_autenticador";
            }

            return "autenticador";
        }

    }
}
