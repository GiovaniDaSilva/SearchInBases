using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SearchInBases.Services
{
    public static class FastColoredTextBoxService
    {

        private static TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        private static TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
        private static TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
        private static TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        private static TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        private static TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        
        public static void TextChanged(TextChangedEventArgs e, FastColoredTextBox campo)
        {
            campo.LeftBracket = '(';
            campo.RightBracket = ')';
            campo.LeftBracket2 = '\0';
            campo.RightBracket2 = '\0';
            e.ChangedRange.ClearStyle(new Style[]
            {
                 BlueStyle,
                 BoldStyle,
                 GrayStyle,
                 MagentaStyle,
                 GreenStyle,
                 BrownStyle
            });
            e.ChangedRange.SetStyle(BrownStyle, "\"\"|@\"\"|''|@\".*?\"|(?<!@)(?<range>\".*?[^\\\\]\")|'.*?[^\\\\]'");
            e.ChangedRange.SetStyle(GreenStyle, "//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, "(/\\*.*?\\*/)|(/\\*.*)", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, "(/\\*.*?\\*/)|(.*\\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);
            e.ChangedRange.SetStyle(MagentaStyle, "\\b\\d+[\\.]?\\d*([eE]\\-?\\d+)?[lLdDfF]?\\b|\\b0x[a-fA-F\\d]+\\b");
            e.ChangedRange.SetStyle(GrayStyle, "^\\s*(?<range>\\[.+?\\])\\s*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(BoldStyle, "\\b(class|struct|enum|interface)\\s+(?<range>\\w+?)\\b");
            e.ChangedRange.SetStyle(BlueStyle, retornaRegexStyleBlue());
            e.ChangedRange.SetStyle(MagentaStyle, retornaRegexStyleMagenta());
            e.ChangedRange.ClearFoldingMarkers();
            e.ChangedRange.SetFoldingMarkers("{", "}");
            e.ChangedRange.SetFoldingMarkers("#region\\b", "#endregion\\b");
            e.ChangedRange.SetFoldingMarkers("/\\*", "\\*/");
        }

        private static string retornaRegexStyleMagenta()
        {
            List<string> palavras = new();      
            palavras.Add("count");            
            palavras.Add("max");
            palavras.Add("min");                        
            palavras.Add("sum");                        
            palavras.Add("mod");                        
            palavras.Add("begin");                        
            palavras.Add("end");
            palavras.Add("cast");



            string aux = retornarPalavras(palavras);
            return $"\\b({aux})\\b|#region\\b|#endregion\\b";
        }

        private static string retornaRegexStyleBlue()
        {
            List<string> palavras = new();
            palavras.Add("select");
            palavras.Add("from");
            palavras.Add("where");
            palavras.Add("group");
            palavras.Add("by");
            palavras.Add("having");
            palavras.Add("switch");
            palavras.Add("case");            
            palavras.Add("alter");
            palavras.Add("asc");
            palavras.Add("desc");            
            palavras.Add("as");
            palavras.Add("do");
            palavras.Add("exists");
            palavras.Add("not");
            palavras.Add("is");
            palavras.Add("inner");
            palavras.Add("left");
            palavras.Add("join");
            palavras.Add("into");
            palavras.Add("lateral");
            palavras.Add("like");
            palavras.Add("between");
            palavras.Add("order");
            palavras.Add("return");
            palavras.Add("on");
            
            string aux = retornarPalavras(palavras);

            return $"\\b({aux})\\b|#region\\b|#endregion\\b";
        }

        private static string retornarPalavras(List<string> palavras)
        {
            string aux = "";
            foreach (var palavra in palavras)
                aux += palavra + "|" + palavra.ToUpper() + "|";
            return aux;
        }
    }
}
