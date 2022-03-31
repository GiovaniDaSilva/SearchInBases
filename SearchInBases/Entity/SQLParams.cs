using System.Collections.Generic;

namespace SearchInBases.Entity
{
    public class SQLParams
    {
        public string sql{ get; set; }
        public string sqlDescript { get; set; }

        public SQLFiltro filtro{ get; set; }

        public List<string> basesFiltradas { get; set; }

        public SQLParams(string sql, SQLFiltro filtro, List<string> basesFiltradas)
        {
            this.sql = sql;
            this.filtro = filtro;
            this.basesFiltradas = basesFiltradas;
        }
    }




    public class SQLFiltro
    {
        public enuStatusBase statusBase;
        public enuAmbiente ambiente;

 
        public SQLFiltro(enuStatusBase statusBase, enuAmbiente ambiente)
        {
            this.statusBase = statusBase;
            this.ambiente = ambiente;
        }

        public enum enuAmbiente
        {
            Interno = 0,
            Producao = 1,
            Ambos = 2
        }

        public enum enuStatusBase
        {
            Ativa = 0,
            Inativa = 1,
            Ambos = 2
        }
    }
}
