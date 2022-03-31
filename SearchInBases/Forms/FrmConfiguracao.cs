using SearchInBases.Services;
using System;
using System.Windows.Forms;
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

            Vars.config.Save();
            Vars.AtualizarConnections();

            this.Close();
        }

        private void FrmConfiguracao_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            txtKeySQL.Text = Vars.config.sqlSecurity.key_descripto_sql;

            ConfiguracaoService.AtualizarListConn(lvConexoes);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                ConfiguracaoService.ValidarConexao(txtNome, txtAutenticador, txtServer, txtUser, txtSenha);

                ConfiguracaoService.AdicionarConn(txtNome, txtAutenticador, txtServer, txtUser, txtSenha);

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
            txtAutenticador.Clear();
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
                txtAutenticador.Text = conn.baseAuth;
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
