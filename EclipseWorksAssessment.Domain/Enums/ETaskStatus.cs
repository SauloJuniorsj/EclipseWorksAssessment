using System.ComponentModel;

namespace EclipseWorksAssessment.Domain.Enums
{
    public enum ETaskStatus
    {
        [Description("Pendente")]
        Pending,
        [Description("Em Andamento")]
        InProgress,
        [Description("Concluída")]
        Done
    }
}
