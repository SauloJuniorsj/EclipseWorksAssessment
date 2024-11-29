using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Application.InputModels
{
    public class CreateTaskInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public ETaskStatus Status { get; set; }
        public ETaskPriority Priority { get; set; }
        public Guid ProjectId { get; set; }
    }
}
