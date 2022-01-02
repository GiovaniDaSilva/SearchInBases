using System;
using System.Drawing;
using System.Windows.Forms;
using static SearchInBases.Services.Config;

namespace SearchInBases.Services
{
    public static class ConfiguracaoService
    {
        public static void RemoverConn(ListView lvConexoes)
        {
            if (lvConexoes.Items.Count <= 0) return;

            var nameConnsSelected = lvConexoes.Items;
            foreach (var nameConn in nameConnsSelected)
            {
                var itemView = (ListViewItem)nameConn;
                if (itemView.Checked)
                {
                    lvConexoes.Items.Remove(itemView);

                    var connRemove = GetConnFromName(itemView.Text);
                    if (connRemove != null)
                        Vars.config.configConn.Remove(connRemove);
                }
            }
        }

        public static ConfigConn? GetConnFromName(string dataBase)
        {
            return Vars.config.configConn.Find(c => c.connName.Equals(dataBase, StringComparison.OrdinalIgnoreCase));
        }

        public static void AdicionarConn(TextBox nome, TextBox autenticador, TextBox server, TextBox user, TextBox senha)
        {
            var conn = GetConnFromName(nome.Text);

            if (conn != null)
                Vars.config.configConn.Remove(conn);

            conn = new ConfigConn(nome.Text,
                                autenticador.Text,
                                server.Text,
                                user.Text,
                                senha.Text);

            Vars.config.configConn.Add(conn);
        }

        public static void SelecionarCor(Button btn)
        {
            ColorDialog dlg = new();
            dlg.CustomColors = new int[] {
                                        ColorTranslator.ToOle(Color.DarkOrange),
                                        ColorTranslator.ToOle(Color.Orange),
                                        ColorTranslator.ToOle(Color.White)
                                      };
            dlg.AnyColor = false;

            dlg.Color = btn.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                btn.BackColor = dlg.Color;
            }
        }

        public static void AtualizarListConn(ListView lvConexoes)
        {
            lvConexoes.Items.Clear();
            foreach (var conn in Vars.config.configConn)
            {
                lvConexoes.Items.Add(conn.connName, 0);
            }
        }

        public static void ValidarConexao(TextBox nome, TextBox autenticador, TextBox server, TextBox user, TextBox senha)
        {
            if (String.IsNullOrWhiteSpace(nome.Text))
                Message.ThrowMsg("Informe o nome da conexão");

            if (String.IsNullOrWhiteSpace(autenticador.Text))
                Message.ThrowMsg("Informe o nome da base do autenticador");

            if (String.IsNullOrWhiteSpace(server.Text))
                Message.ThrowMsg("Informe o servidor");

            if (String.IsNullOrWhiteSpace(senha.Text))
                Message.ThrowMsg("Informe o senha");
        }
        
    }
}
