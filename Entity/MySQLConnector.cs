namespace SearchInBases.Entity
{
    public class MySQLConnector
    {

        public string server { get; set; }
        public string user { get; set; }
        public string password { get; set; }


        public MySQLConnector(string server, string user, string password)
        {
            this.server = server;
            this.user = user;
            this.password = password;
        }

    }
}
