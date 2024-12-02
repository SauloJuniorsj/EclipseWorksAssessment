using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Application.InputModels
{
    public class CreateCommentInputModel
    {
        public EHistoryType HistoryType { get; set; }
        public int TaskId { get; set; }
        public string Changes { get; set; }
        public string Comment { get; set; }
        public string ModifiedBy { get; set; }
        public int UserId { get; set; }
    }
}
