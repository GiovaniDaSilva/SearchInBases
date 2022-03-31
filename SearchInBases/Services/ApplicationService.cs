namespace SearchInBases.Services
{
    public static class ApplicationService
    {
        public static void InicializarAplicacao()
        {
            Vars.config = Config.Load();
            Vars.connections = Vars.config.ToConnections();
            Vars.keySQL = Utils.Decrypt(Vars.config.sqlSecurity.key_descripto_sql);
            HistoricoService.Load();
            GitHubUpdater.CheckNewVersion();
        }
    }
}
