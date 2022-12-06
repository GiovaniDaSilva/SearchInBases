using System;
using System.Collections.Generic;
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
            cbAgenciaTT.Checked = Vars.apenasAgenciaTT;
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
            Vars.apenasAgenciaTT = cbAgenciaTT.Checked;

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

        private void cbAgenciaTT_CheckedChanged(object sender, EventArgs e)
        {
            gbUltimaConsulta.Enabled = !cbAgenciaTT.Checked;
            txtFilter.Enabled = !cbAgenciaTT.Checked;
            if (cbAgenciaTT.Checked)
            {
                rbTodos.Checked = false;
                rbComOcorre.Checked = false;
                rbSemOcorre.Checked = false;
                txtFilter.Clear();
            }            
        }
    }
}
