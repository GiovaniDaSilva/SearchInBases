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
        public MySqlConnection connection { get; set; }
        public bool habilitado { get; set; }
        public List<BaseAuth> basesAuth { get; set; }


        public Connection(string conName, string baseAuth, string server, string user, string password)
        {
            this.mySqlConnector = new MySQLConnector(server, user, password);
            this.connection = MySQLConnectorService.GetMySqlConnection(this.mySqlConnector);
            this.connectionName = conName;
            this.baseAutenticador = baseAuth;
            this.habilitado = false;            
        }

    }
}
