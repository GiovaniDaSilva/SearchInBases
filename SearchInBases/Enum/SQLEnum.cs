using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInBases.Enum
{
    public static class SQLEnum
    {
        public class SQLAuth
        {
            public static string select_instance { get; } = "SELECT id, active, databaseName, internal FROM  {0}.instance";
        }


        public enum SQLAuthInstance : int
        {
            ID = 0,
            ACTIVE = 1,
            DATABASE_NAME = 2,
            INTERNAL = 3
        }

        public class SQLPayScan
        {
            public static string select_basesTT { get; } = "SELECT * FROM  payscan.bases";
        }

    }


   

}
