using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RichTextBoxHTMLFormat
{

    /*
     * Classe criado por Rodrigo Dalpiaz (@digao-dalpiaz) em VB.NET
     * Convertida por Giovani da Silva (@GiovaniDaSilva)
     */

    class MotorRichFmt
    {

        private RichTextBox richTB;
        
        public StringBuilder PureText = new StringBuilder();
       
        //Link
        public static Token LT_Link = new("A", true);

        //Bold
        private static Token LT_Bold = new Token("B", false);

        //Italic
        private static Token LT_Italic = new Token("I", false);

        //Underline
        private static Token LT_Underline = new Token("U", false);

        //Font Color
        private static Token LT_Color = new Token("FC", true);

        //Font Size
        private static Token LT_Size = new Token("FS", true);

        //Font Name
        private static Token LT_Name = new Token("FN", true);

        //Background Color
        private static Token LT_Backgound = new Token("BC", true);


        public Token[] Tokens { get; } = { LT_Link, LT_Bold, LT_Italic, LT_Underline, LT_Color, LT_Size, LT_Name, LT_Backgound };

        public MotorRichFmt(RichTextBox Rich)
        {
            this.richTB = Rich;
        }

        private FontStyle GetStyleByValues(bool bBold, bool bItalic, bool bUnderline)
        {          
            FontStyle fs = 0;

            if (bBold)
                fs = fs | FontStyle.Bold;
            if (bItalic)
                fs = fs | FontStyle.Italic;
            if (bUnderline)
                fs = fs | FontStyle.Underline;
         
            return fs;
        }

        private void InitListas()
        {
            Font fonte = richTB.Font;
            LT_Bold.lst.Add(fonte.Bold);
            LT_Italic.lst.Add(fonte.Italic);
            LT_Underline.lst.Add(fonte.Underline);
            LT_Color.lst.Add(richTB.ForeColor);
            LT_Size.lst.Add(fonte.Size);
            LT_Name.lst.Add(fonte.Name);
            LT_Backgound.lst.Add(richTB.BackColor);
            LT_Link.lst.Add(null);
        }

        private void VerTag(string tag)
        {
            string cmd = Strings.Mid(tag, 2, tag.Length - 2);
            bool Final = cmd.StartsWith("/");
            if (Final)
                cmd = cmd.Remove(0, 1);
            int x = cmd.IndexOf(":") + 1;
            string par = string.Empty;
            
            if (x > 0) // Tag tem parâmetro
            {
                par = Strings.Mid(cmd, x + 1);
                cmd = Strings.Mid(cmd, 1, x - 1);
            }

            cmd = cmd.ToUpper();
            var Tk = (from _tk in Tokens
                      where _tk.tag.Equals(cmd)
                      select _tk).FirstOrDefault();
            
            if (Tk is null)            
                throw new Exception("Token inválido");            

            if (Final)
            {
                int ult = 1;
                if (ReferenceEquals(Tk, LT_Link))
                    ult = 0;
                if (Tk.lst.Count == ult)
                    throw new Exception("Fechamento excedido");
                Tk.DelLast();
            }
            else
            {
                if (Tk.parRequired & String.IsNullOrEmpty(par))                
                    throw new Exception("Parâmetro requerido");                

                Tk.AddMethod(par);
            }

            if (ReferenceEquals(Tk, LT_Link))
                return;
            richTB.SelectionFont = new Font(Conversions.ToString(LT_Name.Prop),
                                          Conversions.ToSingle(LT_Size.Prop), 
                                          GetStyleByValues(Conversions.ToBoolean(LT_Bold.Prop), 
                                                           Conversions.ToBoolean(LT_Italic.Prop), 
                                                           Conversions.ToBoolean(LT_Underline.Prop)));
            richTB.SelectionColor = (Color)LT_Color.Prop;
            richTB.SelectionBackColor = (Color)LT_Backgound.Prop;          
        }

  

        public void DoFmt(string text)
        {
            InitListas();
            while (!String.IsNullOrEmpty(text))
            {
                string a;
                int x;
                if (Conversions.ToString(text[0]) == "<")
                {
                    // Tag
                    x = text.IndexOf(">") + 1;
                    if (x == 0)
                        throw new Exception($"Finalizador da tag '{text}' não encontrado");
                    a = Strings.Mid(text, 1, x);
                    text = text.Remove(0, x);
                    
                    try
                    {
                        VerTag(a);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Erro na tag {a}: {ex.Message}");
                    }
                }
                else
                {
                    // Texto
                    x = text.IndexOf("<") + 1; // Localizar próxima tag
                    if (x == 0)
                        x = text.Length + 1;
                    a = Strings.Mid(text, 1, x - 1);
                    text = text.Remove(0, x - 1);
                    a = a.Replace("&lt;", "<");
                    a = a.Replace("&gt;", ">");

                    if (!String.IsNullOrEmpty((String) LT_Link.Prop))                    
                       addLink(a);                    
                    
                    richTB.SelectedText = a;
                    PureText.Append(a);
                }
            }
        }

        private void addLink(string texto)
        {
            LinkLabel.Link data = new LinkLabel.Link();
            data.LinkData = LT_Link.Prop;

            LinkLabel link = new LinkLabel();
            link.Text = texto;
            link.Links.Add(data);
            link.AutoSize = true;
            link.Location = richTB.GetPositionFromCharIndex(richTB.TextLength);
            link.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            this.richTB.Controls.Add(link);
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
             Process.Start("explorer", e.Link.LinkData.ToString());            
        }        
    }


    class Token
    {
        public List<object> lst = new List<object>();
        public string tag;
        public bool parRequired;
        
        public void AddMethod(string str)
        {
            if (this.tag.Equals("B") || this.tag.Equals("I") || this.tag.Equals("U"))           
                this.lst.Add(true);            
            else if (this.tag.Contains("FC") || this.tag.Contains("BC"))            
                this.lst.Add(Color.FromName(str));            
            else            
                this.lst.Add(str);            
        }

        public Token(string tag, bool parRequired)
        {
            this.tag = tag;
            this.parRequired = parRequired;
        }

        public void DelLast()
        {
            lst.RemoveAt(lst.Count - 1);
        }

        public object Prop
        {
            get
            {
                return lst.Last();
            }
        }
        
    }


    public static partial class RichHTMLFormatting
    {
        public static void RichGoToEnd(RichTextBox Rich)
        {
            Rich.SelectionStart = Rich.TextLength;
        }

        /// <summary>
        /// Adicionado o texto formatado
        /// </summary>
        /// <param name="Rich"></param>
        /// <param name="Text"></param>
        /// <param name="AtEnd"></param>
        public static void RichAddFmt(RichTextBox Rich, string Text, bool AtEnd = true)
        {
            if (AtEnd)
                RichGoToEnd(Rich);
            MotorRichFmt motor = new MotorRichFmt(Rich);
            motor.DoFmt(Text);
        }

        /// <summary>
        /// Adicionado o texto formatado em uma nova linha
        /// </summary>
        /// <param name="Rich"></param>
        /// <param name="Text"></param>
        /// <param name="AtEnd"></param>
        public static void RichAddLineFmt(RichTextBox Rich, string Text, bool AtEnd = true)
        {
            RichAddFmt(Rich, Text + Environment.NewLine, AtEnd);
        }

        public partial class clsRichHTMLFmtVar
        {
            public int StartPos;
            public int Length;
        }

        public static clsRichHTMLFmtVar RichAddFmtVar(RichTextBox Rich, string Text, bool AtEnd = true)
        {
            if (AtEnd)
                RichGoToEnd(Rich);
            var v = new clsRichHTMLFmtVar();
            v.StartPos = Rich.SelectionStart;
            RichAddFmt(Rich, Text, false);
            v.Length = Rich.TextLength - v.StartPos;
            return v;
        }

        public static void RichSetVar(RichTextBox Rich, string Text, clsRichHTMLFmtVar Var)
        {
            var old_pos = Rich.SelectionStart;
            Rich.SelectionStart = Var.StartPos;
            Rich.SelectionLength = Var.Length;
            var old_length = Rich.TextLength;
            RichAddFmt(Rich, Text, false);
            var len_dif = Rich.TextLength - old_length;
            Var.Length += len_dif; // Atualizar tamanho da variável
            Rich.SelectionStart = old_pos + len_dif;
        }

        public static string StringToRtf(string a)
        {            
            a = a.Replace(@"\", @"\\");
            return a;
        }
    }

    public static class RichFormatting { 
    
        public static string Negrito(string texto)
        {
            return "<b>" + texto + "</b>";
        }

        public static string Italico(string texto)
        {
            return "<i>" + texto + "</i>";
        }

        public static string Sublinhado(string texto)
        {
            return "<u>" + texto + "</u>";
        }

        public static string FontColor(string texto, Color color)
        {
            return $"<fc:{color.Name}>" + texto + "</fc>";
        }

        public static string BackgroundColor(string texto, Color color)
        {
            return $"<bc:{color.Name}>" + texto + "</bc>";
        }

        public static string FontSize(string texto, Byte size)
        {            
            return $"<fs:{size}>" + texto + "</fs>";
        }

        public static string FontName(string texto, string name)
        {                        
            return $"<fn:{name}>" + texto + "</fn>";
        }

        public static string Link(string texto, string link)
        {
            return $"<a:{link}>" + texto + "</a>";
        }
    }

}
