using System.ComponentModel;

namespace SearchInBases.Enum
{
    public enum EResultado
    {
        [Description("Ambos")]
        Ambos = 0,
        [Description("Com Ocorrência")]
        ComOcorre = 1,
        [Description("Sem Ocorrência")]
        SemOcorre = 2,
    }
}
