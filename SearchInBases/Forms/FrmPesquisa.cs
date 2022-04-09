﻿using FastColoredTextBoxNS;
using SearchInBases.Entity;
using SearchInBases.Enum;
using SearchInBases.Formularios;
using SearchInBases.Services;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SearchInBases.Entity.SQLFiltro;

namespace SearchInBases.Forms
{
    public partial class FrmPesquisa : Form
    {
        const string status_pesquisa = "Status da Pesquisa: ";
        const string status_processando = status_pesquisa + "Processando...";
        const string status_parado = status_pesquisa + "Parado";

        private PesquisaService _pesquisaService = new PesquisaService();
        private ConsoleService _consoleService;
        private string nomeArquivoResultado;

        public FrmPesquisa()
        {
            InitializeComponent();            
        }

        private void btnExibirConsole_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Visible = !splitContainer1.Panel2.Visible;                        
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            try
            {
                //_pesquisaService.AbrirJsonConfig();
                FrmConfiguracao frmConfig = new FrmConfiguracao();
                frmConfig.ShowDialog();

                AtualizarListConn();

            }
            catch (Exception ex)
            {
                Message.Error("Ocorreu um problema ao abrir as conexões");
                ErroService.TratarErro(ex);
            }            
        }

        private void FrmPesquisa_Load(object sender, EventArgs e)
        {
            this.Text = Vars.appNameWithVersion;
            _consoleService = new ConsoleService(txtConsole);
            lblStatus.Text = status_parado;

            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.btnParar.Top = this.btnPesquisar.Top;
            this.btnParar.Left = this.btnPesquisar.Left;
            this.btnParar.Visible = false;


            AtualizarListConn();
            ExibirBaseFiltradas();
        }

        private void AtualizarListConn()
        {
            lvConexoes.Items.Clear();
            foreach (var conn in Vars.connections)
            {
                conn.habilitado = false;
                lvConexoes.Items.Add(conn.connectionName, 0);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {                        
            try
            {
                LimparConsole();
                ValidarConexoesSelecionadas();
                SQLParams sqlParams = MontarSQLParams();
                _pesquisaService.ValidarComandoSQL(sqlParams);
                sqlParams.sqlDescript = SQLService.TratarParamCamposCripto(sqlParams.sql);

                if (!_pesquisaService.TestarSQL(AtualizaConsole, AlterarStatusApp, sqlParams)) return;

                Vars.resultadoEsperado = GetResultadoEsperado();
                nomeArquivoResultado = CsvService.CriarArquivo(sqlParams);
                Task.Run(() => { _pesquisaService.Pesquisar(AtualizaConsole, AlterarStatusApp, sqlParams, AdicionarResultadoCsv, nomeArquivoResultado); });
                txtConsole.Focus();

            }
            catch (Message.MessageException ex)
            {
                Message.Error(ex.Message);
            }
            catch (Exception ex)
            {
                ErroService.TratarErro(ex);
                Message.Error("Erro ao executar comando");
            }            
        }

        private EResultado GetResultadoEsperado()
        {
            if (rbResultadoComOcorre.Checked)
                return EResultado.ComOcorre;
            else if(rbResultadoSemOcorre.Checked)
                return EResultado.SemOcorre;
            else
                return EResultado.Ambos;
        }

        private void AdicionarResultadoCsv(string texto)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                CsvService.Add(nomeArquivoResultado, texto);
            }));
            
        }

        private void ValidarConexoesSelecionadas()
        {
            if(!Vars.connections.Exists(c => c.habilitado))
            {
                throw new Message.MessageException("Selecione uma conexão para a busca.");
            }
        }

        private void LimparForm()
        {
            txtSQL.Clear();
            LimparConsole();            
            ExibirBaseFiltradas();

        }

        private void ExibirBaseFiltradas()
        {
            lblBasesFiltradas.Visible = Vars.basesFiltradas.Count > 0;
        }

        private void LimparConsole()
        {
            txtConsole.Clear();
            txtConsole.Controls.Clear();           
        }

        private SQLParams MontarSQLParams()
        {
            enuStatusBase statusBase = enuStatusBase.Ambos;
            if (rbAtiva.Checked)
                statusBase = enuStatusBase.Ativa;
            else if(rbInativa.Checked)
                statusBase = enuStatusBase.Inativa;

            enuAmbiente ambiente = enuAmbiente.Ambos;
            if (rbInterno.Checked)
                ambiente = enuAmbiente.Interno;
            else if (rbProducao.Checked)
                ambiente = enuAmbiente.Producao;

            SQLFiltro sqlFiltro = new SQLFiltro(statusBase, ambiente);
            return new SQLParams(txtSQL.Text, sqlFiltro, Vars.basesFiltradas);
        }

        private void AtualizaConsole(string message)
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

        private void AlterarStatusApp()
        {
            this.Invoke(new MethodInvoker(() =>
            {
                bool habilitado = !Vars.isPesquisando;
                
                Vars.pararPesquisa = habilitado;

                btnPesquisar.Enabled = habilitado;
                txtSQL.Enabled = habilitado;
                lvConexoes.Enabled = habilitado;
                toolBar.Enabled = habilitado;
                gbAmbiente.Enabled = habilitado;
                gbBasesAtivas.Enabled = habilitado; 
                btnHistorico.Enabled = habilitado;
                btnFormater.Enabled = habilitado;
                btnFiltrarBases.Enabled = habilitado;
                btnHelp.Enabled = habilitado;  

                
                btnParar.Visible = !habilitado;

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
            LimparForm();
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", Vars.pathResultados);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", Vars.pathLog);
        }

        private void lvConexoes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                if (lvConexoes.Items.Count <= 0) return;                

                var nameConnsSelected = lvConexoes.Items;
                foreach (var nameConn in nameConnsSelected)
                {
                    var itemView = (ListViewItem)nameConn;
                    var conn = Vars.connections.Find(c => c.connectionName.Equals(itemView.Text));
                    if (conn != null) 
                        conn.habilitado = itemView.Checked;
                }
            }
            catch (Exception ex)
            {
                Message.Error("Ocorreu um problema ao selecionar a conexão");
                ErroService.TratarErro(ex);
            }
        }

        private void lvConexoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvConexoes.SelectedItems.Count <= 0) return;

            foreach (var conn in lvConexoes.SelectedItems)
            {
                var itemView = (ListViewItem)conn;
                itemView.Checked = !itemView.Checked;
            }

        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            FrmSobre frmSobre = new FrmSobre();
            frmSobre.ShowDialog();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            FrmHistorico frmHistorico = new FrmHistorico();
            string sql = frmHistorico.RetornaSQLHistorico();
            
            txtSQL.Clear();
            if (!String.IsNullOrEmpty(sql))
            {
                txtSQL.Text = sql;  
            }
        }

        private void btnFormater_Click(object sender, EventArgs e)
        {
            string sql = txtSQL.Text;
            txtSQL.Clear();
            txtSQL.AppendText(SQLService.Formatar(sql));
        }

        private void btnFiltrarBases_Click(object sender, EventArgs e)
        {
            FrmFilterBase frmFiltrarBase = new FrmFilterBase();
            frmFiltrarBase.ShowDialog();

            ExibirBaseFiltradas();
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            Vars.pararPesquisa = true;
            AtualizaConsole("Parando threads...");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            FrmHelp frmHelp = new FrmHelp();
            frmHelp.ShowDialog();
        }

        private void FrmPesquisa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Vars.isPesquisando)
            {
                Message.Info("Pesquisa em andamento... Pare a consulta ou aguarde a conclusão.");
                e.Cancel = true;
            }
                
        }
    }
}
