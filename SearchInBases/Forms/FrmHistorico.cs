using SearchInBases.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SearchInBases.Forms
{
    public partial class FrmHistorico : Form
    {
        private BindingSource bindingSource;
        private string sqlSelecionado;

        private class ColsGrid
        {
            public ColsGrid(DateTime data, string sql)
            {
                this.data = data;
                this.sql = sql;
            }

            public DateTime data { get; set; }
            public string sql { get; set; }
        }

        private List<ColsGrid> dadosGrid = new List<ColsGrid>();

        public FrmHistorico()
        {
            InitializeComponent();
        }

        public string RetornaSQLHistorico()
        {
            this.ShowDialog();
            return sqlSelecionado;
        }

        private void FrmHistorico_Load(object sender, System.EventArgs e)
        {
            InicializarDadosGrid();

            bindingSource = new();
            bindingSource.DataSource = dadosGrid;

            dgvHistorico.DataSource = bindingSource;            
            
            if (dgvHistorico.SelectedRows.Count > 0)
            {
                var item = GetRowSelected();
                txtSQL.Text = item.sql;
            }

        }

        private void InicializarDadosGrid()
        {
            foreach(var consulta in Vars.historico.consultas)
            {
                dadosGrid.Add(new ColsGrid(consulta.data, consulta.sqlParams.sql));
            }
        }

        private void dgvHistorico_Click(object sender, EventArgs e)
        {
            txtSQL.Clear();

            var item = GetRowSelected();            
            txtSQL.AppendText(item.sql);            
        }

        private void btnUtilizar_Click(object sender, EventArgs e)
        {
            if (dgvHistorico.SelectedRows.Count == 0)
            {
                Message.Error("Selecione um SQL para utilizar");
                return;
            }

            var item  = GetRowSelected();
            sqlSelecionado = item.sql;

            this.Close();
        }

        private ColsGrid GetRowSelected()
        {
            foreach (DataGridViewRow row in dgvHistorico.SelectedRows)
            {                
                return row.DataBoundItem as ColsGrid;
            }
            return new ColsGrid(DateTime.Now, "");
        }

        private void txtSQL_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            FastColoredTextBoxService.TextChanged(e, txtSQL);
        }
    }
}
