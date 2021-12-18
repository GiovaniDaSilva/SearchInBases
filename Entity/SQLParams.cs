using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInBases.Entity
{
    public class SQLParams
    {
        public string sql{ get; set; }
        public SQLWhere filtro{ get; set; }

        public SQLParams(string sql, SQLWhere filtro)
        {
            this.sql = sql;
            this.filtro = filtro;
        }

        public string getSQLWithFiltro()
        {
            return sql;
        }       
    }




    public class SQLWhere
    {
        public bool interno { get; set; }
    }
}
