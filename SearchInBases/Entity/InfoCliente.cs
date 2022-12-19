using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInBases.Entity
{
    public class InfoCliente
    {
        [JsonProperty("base")]
        public string nomeBase { get; set; }
        public string instancia { get; set; }
        public bool temAgenciaPaytrack { get; set; }
    }
}
