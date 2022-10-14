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
            add(RichFormatting.FontColor("Tendo configurada a chave de descriptografia em configurações.", Color.Blue) +
                RichFormatting.FontColor(" (Apenas para consultas)", Color.Red));
            add("");
            add("Para descriptografar uma coluna utiliza []");
            add(tab() + RichFormatting.FontColor("Ex: select [campo] from tabela", Color.Gray));
            add("");
            add("Para descriptografar uma coluna que faz parte da condição where utiliza [:]");
            add(tab() + RichFormatting.FontColor("Ex: select campo from tabela where [campo:] ...", Color.Gray));
            add("");
            add(RichFormatting.FontColor("Parâmetros", Color.Blue));
            add("");
            add("Utilize $b para substituir pelo nome da base de dados.");
            add(tab() + RichFormatting.FontColor("Ex: update $b.tabela set campo ...", Color.Gray));
            add("");
            add("Utilize $i, para substituir pela instance da base de dados.");
            add(tab() + RichFormatting.FontColor("Ex: where instance = '$i'...", Color.Gray));           
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
