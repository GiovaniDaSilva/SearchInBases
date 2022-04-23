using RichTextBoxHTMLFormat;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SearchInBases.Forms
{
    public partial class FrmHelp : Form
    {
        public FrmHelp()
        {
            InitializeComponent();
        }

        private void FrmHelp_Load(object sender, EventArgs e)
        {
            add(RichFormatting.FontColor(RichFormatting.Sublinhado("Tendo configurada a chave de descriptografia em configurações."), Color.Blue));
            add("");
            add("Para descriptografar uma coluna utiliza []");
            add(tab() + "Ex: select [campo] from tabela");
            add("");
            add("Para descriptografar uma coluna que faz parte da condição where utiliza [:]");
            add(tab() + "Ex: select campo from tabela where [campo:] ...");

        }

        private string tab(int num = 1)
        {
            string tab = "   ";
            string result = tab;
            if (num <= 0) num = 1;

            for(int i = 0; i < num; i++)            
                result += tab;
            
            return result;
        }

        private void add(string texto)
        {
            RichHTMLFormatting.RichAddLineFmt(help, texto);
        }
    }
}
