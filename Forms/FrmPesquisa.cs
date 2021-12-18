using SearchInBases.Entity;
using SearchInBases.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchInBases.Forms
{
    public partial class FrmPesquisa : Form
    {
        const string status_pesquisa = "Status da Pesquisa: ";
        const string status_processando = status_pesquisa + "Processando...";
        const string status_parado = status_pesquisa + "Parado";

        private PesquisaService _pesquisaService = new PesquisaService();
        private ConsoleService _consoleService;
               
        public FrmPesquisa()
        {
            InitializeComponent();            
        }

        private void btnExibirConsole_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Visible = !splitContainer1.Panel2.Visible;                        
        }

        private void btnConexoes_Click(object sender, EventArgs e)
        {
            try
            {
                _pesquisaService.AbrirJsonConfig();
            }
            catch (Exception ex)
            {
                Message.Error("Ocorreu um problema ao abrir as conexões");
                ErroService.TratarErro(ex);
            }            
        }

        private void FrmPesquisa_Load(object sender, EventArgs e)
        {
            _consoleService = new ConsoleService(txtConsole);
            lblStatus.Text = status_parado;

            foreach (var conn in Vars.connections)
            {
                cblConexoes.Items.Add(conn.connectionName, conn.habilitado);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {                        
            try
            {
                LimparConsole();

                SQLParams sqlParams = montarSQLParams();
                _pesquisaService.validarComandoSQL(sqlParams);
                Task.Run(() => { _pesquisaService.Pesquisar(atualizaConsole, alterarStatusApp, sqlParams); });

            }
            catch (Message.MessageException ex)
            {
                Message.Error(ex.Message);
            }
            catch (Exception ex)
            {
                ErroService.TratarErro(ex);                
            }            
        }

        private void LimparConsole()
        {
            txtConsole.Clear();
            txtConsole.Controls.Clear();
        }

        private SQLParams montarSQLParams()
        {
            return new SQLParams(txtSQL.Text, null);
        }

        private void cblConexoes_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {                
                if (cblConexoes.SelectedIndex <= -1) return;

                var nameConnSelected = cblConexoes.SelectedItem;                
                foreach (var conn in Vars.connections)
                {
                    if (conn.connectionName.Equals(nameConnSelected))
                    {
                        conn.habilitado = cblConexoes.GetItemChecked(cblConexoes.SelectedIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                Message.Error("Ocorreu um problema ao selecionar a conexão");
                ErroService.TratarErro(ex);
            }            
        }

        private void atualizaConsole(string message)
        {
            this.Invoke(new MethodInvoker(() =>
            {                
                _consoleService.AddLine(message);                
            }));
        }

        private void IniciarProgresso()
        {          
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;                     
        }

        private void PararProgresso()
        {          
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.MarqueeAnimationSpeed = 0;                   
        }

        private void alterarStatusApp()
        {
            this.Invoke(new MethodInvoker(() =>
            {
                bool habilitado = !Vars.isPesquisando;

                btnPesquisar.Enabled = habilitado;
                txtSQL.Enabled = habilitado;
                cblConexoes.Enabled = habilitado;
                toolBar.Enabled = habilitado;

                if (!habilitado)
                {
                    IniciarProgresso();
                    lblStatus.Text = status_processando;
                }
                else
                {
                    PararProgresso();
                    lblStatus.Text = status_parado;
                }
                    
            }));                                   
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LimparConsole();
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", Vars.pathResultados);
        }
    }
}
