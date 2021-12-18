using System;
using System.Windows.Forms;

namespace SearchInBases
{
    public static class Message
    {
            private static string titulo = Vars.appName;


        
        public static void InfoPesquisaFinalizada()
        {
            MessageBox.Show("Pesquisa finalizada.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Information); 
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
