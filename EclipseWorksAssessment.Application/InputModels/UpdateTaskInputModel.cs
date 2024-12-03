using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Application.InputModels
{
    public class UpdateTaskInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public ETaskStatus Status { get; set; }
    }
}
