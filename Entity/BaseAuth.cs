using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInBases.Entity
{
    public class BaseAuth
    {
        public BaseAuth(string instance, string databaseName, bool interno, bool ativo)
        {
            this.instance = instance;
            this.databaseName = databaseName;
            this.interno = interno;
            this.ativo = ativo;
        }

        public string instance { get; set; }
        public string databaseName { get; set; }
        public bool interno { get; set; }
        public bool  ativo { get; set; }
    }
}
