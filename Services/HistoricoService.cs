using Newtonsoft.Json;
using SearchInBases.Entity;
using System.IO;

namespace SearchInBases.Services
{
    public static class HistoricoService
    {
       
        public static string GetHistoricoFile()
        {
            return Vars.pathHistorico;
        }

        public static void Load()
        {
            
            var path = GetHistoricoFile();

            if (File.Exists(path))
            {
                var data = File.ReadAllText(path);
                Vars.historico = JsonConvert.DeserializeObject<Historico>(data);

                if (Utils.IsNullOrEmpty(Vars.historico.consultas))
                {
                    Vars.historico = new Historico();
                }
            }
            else
            {
                Vars.historico = new Historico();                
            }
                                                
        }

        public static void Save()
        {
            var path = GetHistoricoFile();
            var data = JsonConvert.SerializeObject(Vars.historico, Formatting.Indented);
            File.WriteAllText(path, data);
        }

    }
}
