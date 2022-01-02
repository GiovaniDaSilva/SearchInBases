namespace SearchInBases.Services
{
    public static class ApplicationService
    {
        public static void InicializarAplicacao()
        {
            Vars.config = Config.Load();
            Vars.connections = Vars.config.ToConnections();       
            HistoricoService.Load();
            GitHubUpdater.CheckNewVersion();
        }
    }
}
