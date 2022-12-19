using SearchInBases.Entity;
using SearchInBases.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchInBases.Forms
{
    public partial class FrmFilterBase : Form
    {
        public FrmFilterBase()
        {
            InitializeComponent();
        }

        private void FrmFilterBase_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(400, 500);

            if(Vars.basesFiltradas.Count > 0)
            {
                Vars.basesFiltradas.ForEach(b => AppendBase(b));
            }
            lblPesquisando.Visible = false;
        }

        private void AppendBase(string b)
        {
            txtFilter.AppendText(b + Environment.NewLine);
        }

        private void btnUtilizar_Click(object sender, EventArgs e)
        {  
            Vars.basesFiltradas.Clear();

            TratarBasesFiltradas();

            this.Close();
        }

        private void TratarBasesFiltradas()
        {
            if (String.IsNullOrEmpty(txtFilter.Text.Trim()))
                return;

            List<string> bases = new List<string>();
            txtFilter.Text = txtFilter.Text.Replace(" ", "_");
            bases.AddRange(txtFilter.Text.Trim().Split(Environment.NewLine));            
            
            Vars.basesFiltradas.AddRange(bases);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            rbComOcorre.Checked = false;
            rbSemOcorre.Checked = false;
            rbTodos.Checked = false;
            rbComTT.Checked = false;
            rbSemTT.Checked = false;
            LimparBases();
        }

        private void LimparBases()
        {
            txtFilter.Clear();
        }

   

        private void ImportarBasesFiltros()
        {
            if (Vars.basesUltimaConsulta.Count == 0)
                Message.Info("Realize uma pesquisa antes de importar as bases da última consulta");

            LimparBases();

            foreach (var baseUltCon in Vars.basesUltimaConsulta)
            {
                if (rbTodos.Checked
                    || (rbComOcorre.Checked && baseUltCon.encontrouRegistro)
                    || (rbSemOcorre.Checked && !baseUltCon.encontrouRegistro))
                    AppendBase(baseUltCon.databaseName);
            }
        }

        private void rbTodos_Click(object sender, EventArgs e)
        {            
            ImportarBasesFiltros();
        }

        private void rbComOcorre_Click(object sender, EventArgs e)
        {            
            ImportarBasesFiltros();
        }

        private void rbSemOcorre_Click(object sender, EventArgs e)
        {            
            ImportarBasesFiltros();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(!rbComTT.Checked && !rbSemTT.Checked)
            {
                Message.Error("Selecione uma opção");
                return;
            }

            if (Utils.IsNullOrEmpty(Vars.connections.FindAll(c => c.habilitado)))
            {
                Message.Error("Nenhuma conexão selecionada");
                return;
            }

            Pesquisando(true);
            Task.Run(() => { Pesquisar(); });
        }



        private void Pesquisar()
        {
            try
            {
                List<Connection> conexoesHabilitadas = Vars.connections.FindAll(c => c.habilitado);                

                List<string> clientesTT = null;

                conexoesHabilitadas.ForEach(c =>
                {
                    if (clientesTT != null) return;

                    try
                    {
                        clientesTT = BuscarBasesAgenciaTT(c);
                    }
                    catch (Exception ex)
                    {
                        Log.addErroMessage("Erro ao buscar clientes TT - Conn: " + c.connectionName + " Erro: " + ex.Message);
                    }
                });

                if (clientesTT == null)
                {
                    Message.Error("Não foi possível buscar os clientes TT, consulte o log.");
                    return;
                }

                txtFilter.Clear();
                clientesTT.ForEach(c => AppendBase(c));
            }
            finally
            {
                finaizarPesquisa();
            }                        
        }

        private void finaizarPesquisa()
        {
            this.Invoke(new MethodInvoker(() =>
            {
                Pesquisando(false);
            }));
        }


        private void Pesquisando(bool pesquisando)
        {
            lblPesquisando.Visible = pesquisando;
            btnImportarAgenciasTT.Enabled = !pesquisando;
        }

        private List<string> BuscarBasesAgenciaTT(Connection conn)
        {
            bool comAgenciaTT = rbComTT.Checked;
            if (Vars.infoClientes != null)
            {
                Log.AddMessage(String.Format("Bases {0} agência TT pegas em memoria", comAgenciaTT ? "com" : "sem"));
                return getListaDatabaseName(Vars.infoClientes, comAgenciaTT);
            }

            Log.AddMessage("Buscando info clientes");
            Vars.infoClientes = ConnectionService.buscarBasesAgenciaTT(conn);
            return getListaDatabaseName(Vars.infoClientes, comAgenciaTT);
        }

        private static List<string> getListaDatabaseName(List<InfoCliente> infoClientes, bool agenciaTT)
        {
            List<string> bases = new List<string>();
            infoClientes.FindAll(i=> i.temAgenciaPaytrack.Equals(agenciaTT)).ForEach(b => bases.Add(b.nomeBase));
            return bases;
        }
    }
}
