namespace SearchInBases.Entity
{
    public class BaseUltimaConsulta
    {
        public BaseUltimaConsulta(string instance, string databaseName, bool encontrouRegistro)
        {
            this.instance = instance;
            this.databaseName = databaseName;
            this.encontrouRegistro = encontrouRegistro;
        }

        public string instance { get; set; }
        public string databaseName { get; set; }
        public bool encontrouRegistro { get; set; }
    }
}
