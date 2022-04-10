using System.Collections.Generic;

namespace SearchInBases.Entity
{
    public class BaseConsulta : BaseUltimaConsulta
    {
        public BaseConsulta(BaseUltimaConsulta baseUltimaConsulta, string headerColumns, List<string> resultadoConsulta) : base(baseUltimaConsulta.instance, baseUltimaConsulta.databaseName, baseUltimaConsulta.encontrouRegistro)
        {
            this.headerColumns = headerColumns;
            this.resultadoConsulta = resultadoConsulta;
        }

        public string headerColumns { get; set; }

        public List<string> resultadoConsulta { get; set; }

    }
}
