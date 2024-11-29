using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Application.ViewModels
{
    public class TaskViewModel
    {
        public TaskViewModel(Guid id, string title, string description, DateTimeOffset dueDate, ETaskStatus status, ETaskPriority priority, Guid projectId)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
            ProjectId = projectId;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public ETaskStatus Status { get; set; }
        public ETaskPriority Priority { get; set; }
        public Guid ProjectId { get; set; }
    }
}
