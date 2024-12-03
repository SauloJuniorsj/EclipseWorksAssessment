using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Application.ViewModels
{
    public class TaskViewModel
    {
        public TaskViewModel(int id, string title, string description, DateTimeOffset dueDate, ETaskStatus status, ETaskPriority priority, int projectId, DateTimeOffset dateCreated, DateTimeOffset dateDelete)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
            ProjectId = projectId;
            DateCreated = dateCreated;
            DateDeleted = dateDelete;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public ETaskStatus Status { get; set; }
        public ETaskPriority Priority { get; set; }
        public int ProjectId { get; set; }
        public  DateTimeOffset DateCreated{ get; set; }
        public  DateTimeOffset DateDeleted{ get; set; }

    }
}
