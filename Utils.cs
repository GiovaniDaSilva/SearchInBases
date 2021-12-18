using MySqlConnector;
using SearchInBases.Entity;
using System;
using System.Collections.Generic;

namespace SearchInBases
{
    public static class Utils
    {
        private static string format_date_name = "dd-MM-yyyy HHmmss";

        public static bool IsNullOrEmpty<T>(List<T> lista)
        {
            if (lista == null) return true;
            if (lista.Count <= 0) return true;
            return false;
        }

        public static bool IsNull<T>(List<T> lista)
        {
            return (lista == null);
        }

        public static string FormatDateTimeToName(DateTime data)
        {
            return data.ToString(format_date_name);
        }

    }
}
