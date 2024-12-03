using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(ProjectEntity model)
        {
            if (model == null)
            {
                return;
            }

            Id = model.Id;
            Name = model.Name;
            User = new UserViewModel(model.User.Id, model.User.Name, null);
            Tasks = new CollectionTasksViewModel(model.Tasks);
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public UserViewModel User { get; set; }
        public CollectionTasksViewModel Tasks { get; set; }
    }
}
