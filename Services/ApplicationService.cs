using SearchInBases.Entity;
using SearchInBases.Forms;
using System.Windows.Forms;

namespace SearchInBases.Services
{
    public static class ApplicationService
    {
        public static void InicializarAplicacao()
        {
            Vars.config = Config.Load();
            Vars.connections = Vars.config.getConnections();            
            GitHubUpdater.CheckNewVersion();
        }
    }
}
