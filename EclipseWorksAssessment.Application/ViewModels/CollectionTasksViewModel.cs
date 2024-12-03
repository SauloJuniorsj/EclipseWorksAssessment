using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Application.ViewModels
{
    public class CollectionTasksViewModel
    {
        public CollectionTasksViewModel()
        {
            
        }
        public List<TaskViewModel> CollectionTask { get; set; }

        public CollectionTasksViewModel(List<TaskEntity> collection)
        {
            if (collection == null)
            {
                CollectionTask = new List<TaskViewModel>();
                return;
            }

            CollectionTask = collection.Select(x =>
                new TaskViewModel(
                    x.Id,
                    x.Title,
                    x.Description,
                    x.DueDate,
                    x.Status,
                    x.Priority,
                    x.ProjectId,
                    x.DateCreated,
                    x.DateDeleted
                    ))
                .ToList();
        }
    }
}
