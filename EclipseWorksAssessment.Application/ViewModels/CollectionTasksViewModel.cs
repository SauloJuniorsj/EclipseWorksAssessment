using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Application.ViewModels
{
    public class CollectionTasksViewModel
    {
        public IEnumerable<TaskViewModel> CollectionProject { get; set; }

        public CollectionTasksViewModel(IEnumerable<TaskEntity> collection)
        {
            CollectionProject = collection.Select(x => 
            new TaskViewModel(x.Id,
            x.Description,
            x.Title,
            x.DueDate,
            x.Status,
            x.Priority,
            x.ProjectId));
        }
    }
}
