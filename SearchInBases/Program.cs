using SearchInBases.Forms;
using SearchInBases.Services;
using System;
using System.Windows.Forms;

namespace SearchInBases
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationService.InicializarAplicacao();
            Application.Run(new FrmPesquisa());            
        }
    }
}
