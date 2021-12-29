using System;
using System.Collections.Generic;

namespace SearchInBases.Entity
{
    public class Historico
    {
        public List<DadosConsulta> consultas { get; set; }

        public Historico()
        {
            consultas = new List<DadosConsulta>();
        }
    }

    public class DadosConsulta
    {
        public DadosConsulta(SQLParams sqlParams)
        {
            this.sqlParams = sqlParams;            
            this.data = DateTime.Now;
            Vars.connections.FindAll(c => c.habilitado)
                .ForEach(conn => this.conns.Add(conn.connectionName));
        }

        public DateTime data { get; set; }
        public List<string> conns { get; set; } = new List<string>();
        public SQLParams sqlParams { get; set; }        
    }
    
}
