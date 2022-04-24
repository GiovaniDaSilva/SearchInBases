using System;
using System.Windows.Forms;

namespace SearchInBases
{
    public static class Message
    {
            private static string titulo = Vars.appName;

        
        public static void MessagemPesquisaFinalizada(bool ocorreuErroNaConsulta, DateTime dtInicio, bool script = false)
        {
            DateTime dtFim = DateTime.Now;
            TimeSpan timeSpan = dtFim.Subtract(dtInicio);
            string tempoPesquisa = "Tempo: " + timeSpan.Hours.ToString("00") + ":" + timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");

            string termo = script ? "Script finalizado" : "Pesquisa finalizada";

            string msg = $"{termo} com {(!ocorreuErroNaConsulta ? "sucesso" : "erro")}. " + tempoPesquisa;            
            MessageBox.Show(msg, titulo, MessageBoxButtons.OK, !ocorreuErroNaConsulta ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            Log.AddMessage(msg);
        }


        # region "Msg Tipos"
        public static void Error(string msg)
        {
            Log.AddMessage(msg);
            MessageBox.Show(msg, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Info(string msg)
        {
            Log.AddMessage(msg);
            MessageBox.Show(msg, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Question(string msg)
        {
            Log.AddMessage(msg);
            return MessageBox.Show(msg, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
        #endregion



        #region "Erro"

        public class MessageException : Exception
        {
            public MessageException(string message) : base(message)
            {
            }
        }

        public static void ThrowMsg(string msg)
        {
            throw new MessageException(msg);
        }

        public static void SurroundMessageException(Action proc)
        {
            try
            {
                proc();
            }
            catch (MessageException msgEx)
            {
                Error(msgEx.Message);
            }
        }
        #endregion

    }

}
