using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public TaskEntity(string title, string description, DateTimeOffset dueDate, ETaskStatus status, ETaskPriority priority, int projectId)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
            ProjectId = projectId;

            DateCreated = DateTime.UtcNow;
            UserComments = new List<UserCommentEntity>();
        }
        public TaskEntity(string title, string description, DateTimeOffset dueDate, ETaskStatus status, int projectId)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            ProjectId = projectId;

            DateUpdated = DateTime.UtcNow;
            UserComments = new List<UserCommentEntity>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public ETaskStatus Status { get; set; }
        public ETaskPriority Priority { get; set; }
        public int ProjectId { get; set; }

        public virtual List<UserCommentEntity> UserComments { get; set; }
        public virtual ProjectEntity Project { get; set; }

        public void UpdateTask(string title, string description, DateTimeOffset dueDate, ETaskStatus status)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
        }
    }
}
