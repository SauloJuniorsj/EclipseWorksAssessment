using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Application.InputModels
{
    public class CreateUserCommentInputModel
    {
        public EHistoryType HistoryType { get; set; }
        public int TaskId { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
    }
}
