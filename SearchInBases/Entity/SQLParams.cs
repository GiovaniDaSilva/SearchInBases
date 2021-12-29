namespace SearchInBases.Entity
{
    public class SQLParams
    {
        public string sql{ get; set; }
        public SQLFiltro filtro{ get; set; }

        public SQLParams(string sql, SQLFiltro filtro)
        {
            this.sql = sql.ToLower();
            this.filtro = filtro;
        }

        public string GetSQL()
        {
            return sql;
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
