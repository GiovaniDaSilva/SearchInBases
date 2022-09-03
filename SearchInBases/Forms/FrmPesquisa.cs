using FastColoredTextBoxNS;
using RichTextBoxHTMLFormat;
using SearchInBases.Entity;
using SearchInBases.Enum;
using SearchInBases.Formularios;
using SearchInBases.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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
        private List<BaseConsulta> _listaConsultas = new List<BaseConsulta> { };
        private string _nomeArquivoResultado;

        private EResultado _resultadoEsperadoAux = EResultado.ComOcorre;

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
            InicializarForm();

            AjustarModoScript();

            AtualizarListConn();
            ExibirBaseFiltradas();
        }

        private void InicializarForm()
        {
            this.Text = Vars.appNameWithVersion;
            _consoleService = new ConsoleService(txtConsole);
            lblStatus.Text = status_parado;

            this.MinimumSize = new System.Drawing.Size(900, 600);

            this.btnParar.Top = this.btnPesquisar.Top;
            this.btnParar.Left = this.btnPesquisar.Left;
            this.btnParar.Visible = false;

            this.btnScript.Top = this.btnPesquisar.Top;
            this.btnScript.Left = this.btnPesquisar.Left;
            this.btnScript.Visible = false;
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
                InicializarBusca();
                SQLParams sqlParams = GetSQLParams();

                if (!_pesquisaService.TestarSQL(AtualizaConsole, AlterarStatusApp, sqlParams)) return;

                Vars.resultadoEsperado = GetResultadoEsperado();
                _nomeArquivoResultado = CsvService.CriarArquivoCSV(sqlParams);
                Task.Run(() => { _pesquisaService.Pesquisar(AtualizaConsole, AlterarStatusApp, sqlParams, AdicionarResultado, _nomeArquivoResultado, FinalizarBuscaCsv); });
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

        private void InicializarBusca()
        {
            LimparConsole();
            ValidarConexoesSelecionadas();
            _listaConsultas.Clear();
        }

        private SQLParams GetSQLParams(bool validarSQL = true)
        {
            SQLParams sqlParams = MontarSQLParams();
            if (validarSQL) _pesquisaService.ValidarComandoSQL(sqlParams);
            sqlParams.sqlDescript = SQLService.TratarParamCamposCripto(sqlParams.sql);
            return sqlParams;
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

        private void setResultadoEsperado(EResultado resultado)
        {
            if (EResultado.ComOcorre.Equals(resultado))
                rbResultadoComOcorre.Checked = true;
            else if (EResultado.SemOcorre.Equals(resultado))
                rbResultadoSemOcorre.Checked = true;
            else
                rbResultadoAmbos.Checked = true;
        }

        public void FinalizarBuscaCsv()
        {
            this.Invoke(new MethodInvoker(() =>
            {
                AdicionarResumoPesquisaConsole(_listaConsultas);
                CsvService.FinalizarArquivoCsv(_nomeArquivoResultado, _listaConsultas, Vars.resultadoEsperado);
            }));
        }

        public void FinalizarBuscaSql()
        {
            this.Invoke(new MethodInvoker(() =>
            {
                CsvService.FinalizarArquivoSql(_nomeArquivoResultado, _listaConsultas);
            }));
        }

        private void AdicionarResultado(BaseConsulta baseConsulta)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                _listaConsultas.Add(baseConsulta);                                
            }));
            
        }

        private void ValidarConexoesSelecionadas()
        {
            if(!Vars.connections.Exists(c => c.habilitado))
            {
                throw new Message.MessageException("Selecione uma conexão para a busca.");
            }
        }

        private void AdicionarResumoPesquisaConsole(List<BaseConsulta>  resultado)
        {
            int qtdComOcorre = resultado.FindAll(r => r.encontrouRegistro).Count;
            int qtdSemOcorre = resultado.FindAll(r => !r.encontrouRegistro).Count;

            int qtdRegistros = 0;
            
            if (EResultado.ComOcorre.Equals(Vars.resultadoEsperado))
                resultado.FindAll(r=> r.encontrouRegistro).ForEach(c => qtdRegistros += c.resultadoConsulta.Count);
            else if (EResultado.SemOcorre.Equals(Vars.resultadoEsperado))
                resultado.FindAll(r => !r.encontrouRegistro).ForEach(c => qtdRegistros += c.resultadoConsulta.Count);
            else
                resultado.ForEach(c => qtdRegistros += c.resultadoConsulta.Count);

            byte tamanho = 10;
            _consoleService.AddLine("------------------------------------------------------");
            _consoleService.AddLine(RichFormatting.FontSize(RichFormatting.Negrito("Resumo:"), tamanho));
            _consoleService.AddLine(RichFormatting.FontSize(numeroConsole(qtdComOcorre, Color.Green) + " bases com ocorrência", tamanho));
            _consoleService.AddLine(RichFormatting.FontSize(numeroConsole(qtdSemOcorre, Color.Red) + " bases sem ocorrência", tamanho));
            _consoleService.AddLine(RichFormatting.FontSize("Total de registros na consulta: " + numeroConsole(qtdRegistros, Color.DarkMagenta), tamanho));
            _consoleService.AddLine("------------------------------------------------------");
        }

        private string numeroConsole(int valor, Color color)
        {
            return RichFormatting.Negrito(RichFormatting.FontColor(valor.ToString(), color));
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
                gbResultado.Enabled = habilitado && !tgAcao.Checked;
                tgAcao.Enabled = habilitado;


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

        private void tgAcao_CheckedChanged(object sender, EventArgs e)
        {
            AjustarModoScript();
        }

        private void AjustarModoScript()
        {
            bool isScript = tgAcao.Checked;

            btnPesquisar.Visible = !isScript;
            btnScript.Visible = isScript;
            gbResultado.Enabled = !isScript;

            if (isScript)
            {
                _resultadoEsperadoAux = GetResultadoEsperado();

                rbResultadoAmbos.Checked = false;
                rbResultadoComOcorre.Checked = false;
                rbResultadoSemOcorre.Checked = false;
            }
            else if(!Vars.isPesquisando)
            {              
               setResultadoEsperado(_resultadoEsperadoAux);                
            }                                 
        }

        private void btnScript_Click(object sender, EventArgs e)
        {
            try
            {
                InicializarBusca();
                SQLParams sqlParams = GetSQLParams(false);
                
                _nomeArquivoResultado = CsvService.CriarArquivoSQL(sqlParams);
                Task.Run(() => { _pesquisaService.GerarScript(AtualizaConsole, AlterarStatusApp, sqlParams, AdicionarResultado, _nomeArquivoResultado, FinalizarBuscaSql); });
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
    }
}
