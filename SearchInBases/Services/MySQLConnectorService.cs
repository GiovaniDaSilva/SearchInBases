using MySqlConnector;
using SearchInBases.Entity;

namespace SearchInBases.Services
{
    public static class MySQLConnectorService
    {
        
        public static MySqlConnection GetMySqlConnection(SearchInBases.Entity.MySQLConnector mySqlConnector)
        {
            string stringConn = $"Server={mySqlConnector.server};User ID={mySqlConnector.user};Password={mySqlConnector.password}";
            return new MySqlConnection(stringConn);
        }


        public static MySqlDataReader ExecutarSQL(MySqlConnection conn, SQLParams sqlParams)
        {
            return ExecutarSQL(conn, sqlParams.GetSQL());
        }

        public static MySqlDataReader ExecutarSQL(MySqlConnection conn, string sql)
        {
            using (var command = new MySqlCommand(sql, conn))
            {
                return command.ExecuteReader();
            }              
        }     
    }
    
}
