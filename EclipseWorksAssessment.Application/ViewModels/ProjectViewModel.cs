using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TaskViewModel> Tasks { get; set; }
    }
}
