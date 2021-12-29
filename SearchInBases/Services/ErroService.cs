using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInBases.Services
{
    public static class ErroService
    {
        public static void TratarErro(Exception ex)
        {        
            Log.addErroMessage(ex.Message);
            Log.addErroMessage(ex.StackTrace);
        }
    }
}
