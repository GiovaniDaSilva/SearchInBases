using SearchInBases.Enum;
using SearchInBases.Services;
using System;
using System.Windows.Forms;
using static SearchInBases.Entity.SQLFiltro;
using static SearchInBases.Services.Config;

namespace SearchInBases.Formularios
{
    public partial class FrmConfiguracao : Form
    {
        
        public FrmConfiguracao()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            Vars.config.sqlSecurity.key_descripto_sql = txtKeySQL.Text.Trim();
            Vars.keySQL = Utils.Decrypt(Vars.config.sqlSecurity.key_descripto_sql);

            enuStatusBase statusBase = enuStatusBase.Ambos;
            if (rbAtiva.Checked)
                statusBase = enuStatusBase.Ativa;
            else if (rbInativa.Checked)
                statusBase = enuStatusBase.Inativa;

            enuAmbiente ambiente = enuAmbiente.Ambos;
            if (rbInterno.Checked)
                ambiente = enuAmbiente.Interno;
            else if (rbProducao.Checked)
                ambiente = enuAmbiente.Producao;

            EResultado resultado = EResultado.Ambos;
            if (rbResultadoComOcorre.Checked)
                resultado = EResultado.ComOcorre;
            else if (rbResultadoSemOcorre.Checked)
                resultado = EResultado.SemOcorre;
            
            Vars.config.configFiltros.resultado = resultado;
            Vars.config.configFiltros.sqlFiltro.ambiente = ambiente;
            Vars.config.configFiltros.sqlFiltro.statusBase = statusBase;
            
            Vars.config.configFiltros.imprimirCabecalho = cbImprimirCabecalho.Checked;

            Vars.config.Save();
            Vars.AtualizarConnections();

            this.Close();
        }

        private void FrmConfiguracao_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            txtKeySQL.Text = Vars.config.sqlSecurity.key_descripto_sql;
            
            switch (Vars.config.configFiltros.resultado)
            {
                case Enum.EResultado.ComOcorre: 
                    rbResultadoComOcorre.Checked = true;
                    break;
                case Enum.EResultado.SemOcorre: 
                    rbResultadoSemOcorre.Checked = true;
                    break;
                default: rbResultadoAmbos.Checked = true;
                    break;
            }

            switch (Vars.config.configFiltros.sqlFiltro.ambiente)
            {
                case Entity.SQLFiltro.enuAmbiente.Interno:
                    rbInterno.Checked = true;
                    break;
                case Entity.SQLFiltro.enuAmbiente.Producao:
                    rbProducao.Checked = true;
                    break;
                default:
                    rbAmbosAmbiente.Checked = true;
                    break;
            }

            switch (Vars.config.configFiltros.sqlFiltro.statusBase)
            {
                case Entity.SQLFiltro.enuStatusBase.Ativa:
                    rbAtiva.Checked = true;
                    break;
                case Entity.SQLFiltro.enuStatusBase.Inativa:
                    rbInativa.Checked = true;
                    break;
                default:
                    rbAmbasAtiva.Checked = true;
                    break;
            }

            cbImprimirCabecalho.Checked = Vars.config.configFiltros.imprimirCabecalho;

            ConfiguracaoService.AtualizarListConn(lvConexoes);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                ConfiguracaoService.ValidarConexao(txtNome, txtServer, txtUser, txtSenha);

                ConfiguracaoService.AdicionarConn(txtNome, txtServer, txtUser, txtSenha);

                ConfiguracaoService.AtualizarListConn(lvConexoes);
                LimparCamposConn();
            }
            catch (Exception ex)
            {
                ErroService.TratarErro(ex);
            }            
        }

        private void LimparCamposConn()
        {
            txtNome.Clear();            
            txtServer.Clear();
            txtUser.Clear();
            txtSenha.Clear();
        }

        private void lvConexoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvConexoes.SelectedItems.Count <= 0) return;

                foreach (var conn in lvConexoes.SelectedItems)
                {
                    var itemView = (ListViewItem)conn;
                    itemView.Checked = !itemView.Checked;

                    CarregarCamppos(itemView);
                }
            }
            catch (Exception ex)
            {
                ErroService.TratarErro(ex);
            }           
        }

        private void CarregarCamppos(ListViewItem itemView)
        {
            LimparCamposConn();

            ConfigConn? conn = ConfiguracaoService.GetConnFromName(itemView.Text);
            if (conn != null)
            {
                txtNome.Text = conn.connName;                
                txtServer.Text = conn.server;
                txtUser.Text = conn.user;
                txtSenha.Text = conn.password;
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                ConfiguracaoService.RemoverConn(lvConexoes);
                LimparCamposConn();
            }
            catch (Exception ex)
            {
                ErroService.TratarErro(ex);
            }           
        }
    }
}
