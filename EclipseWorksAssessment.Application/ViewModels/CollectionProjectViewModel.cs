using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Application.ViewModels
{
    public class CollectionProjectViewModel
    {
        public CollectionProjectViewModel()
        {
            CollectionProject = new List<ProjectViewModel>();
        }
        public List<ProjectViewModel> CollectionProject { get; set; }

        public CollectionProjectViewModel(List<ProjectEntity> collection)
        {
            CollectionProject = new List<ProjectViewModel>();

            CollectionProject = collection.Select(x => new ProjectViewModel(x)).ToList();
        }
    }
}
