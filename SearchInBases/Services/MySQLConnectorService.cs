﻿using MySqlConnector;
using SearchInBases.Entity;

namespace SearchInBases.Services
{
    public static class MySQLConnectorService
    {
        
        public static MySqlConnection GetMySqlConnection(SearchInBases.Entity.MySQLConnector mySqlConnector)
        {
         
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Server = mySqlConnector.server.ToLower(),                
                UserID = mySqlConnector.user.ToLower(),
                Password = mySqlConnector.password,           
                Pooling = true,
                MaximumPoolSize = 20,                  
                SslMode = MySqlSslMode.None,
                AllowPublicKeyRetrieval = true,
                ApplicationName = Vars.appName,
            };

            string connString = builder.ConnectionString;

            return new MySqlConnection(connString);
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
