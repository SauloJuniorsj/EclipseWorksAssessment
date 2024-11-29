using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Domain.Entities
{
    public sealed class TaskEntity : BaseEntity
    {
        public TaskEntity(string title, string description, DateTimeOffset dueDate, ETaskStatus status, ETaskPriority priority, Guid projectId)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
            ProjectId = projectId;

            DateCreated = DateTime.UtcNow;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public ETaskStatus Status { get; set; }
        public ETaskPriority Priority { get; set; }
        public Guid ProjectId { get; set; }

        public ProjectEntity Project { get; set; }

        public void UpdateTask(string title, string description, DateTimeOffset dueDate, ETaskStatus status)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
        }
    }
}
