using RichTextBoxHTMLFormat;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchInBases.Services
{
    public class ConsoleService
    {

        private RichTextBox _console;        

        public ConsoleService(RichTextBox console)
        {
            _console = console;
        }

        public void AddLine(string message)
        {            
            var dateTime = DateTime.Now;
            RichHTMLFormatting.RichAddLineFmt(_console, RichFormatting.Negrito($"[{dateTime}]") + $" - {message}");            
        }

    }


    public class DadosConsole
    {        
        public DateTime dateTime { get; set; }
        public string message { get; set; }
    }
}
