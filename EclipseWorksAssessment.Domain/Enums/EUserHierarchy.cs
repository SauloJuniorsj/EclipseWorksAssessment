using System.ComponentModel;

namespace EclipseWorksAssessment.Domain.Enums
{
    public enum EUserHierarchy
    {
        [Description("Admin")]
        Admin,
        [Description("Operador")]
        Operator,
        [Description("Gerente")]
        Manager
    }
}
