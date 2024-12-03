using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ProjectViewModel(ProjectEntity model)
        {
            if (model == null)
            {
                return;
            }
            Id = model.Id;
            Name = model.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public UserViewModel User { get; set; }
        public List<TaskViewModel> Tasks { get; set; }
    }
}
