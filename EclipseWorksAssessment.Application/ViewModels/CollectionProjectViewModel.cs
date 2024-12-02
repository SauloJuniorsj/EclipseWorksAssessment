using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Application.ViewModels
{
    public class CollectionProjectViewModel
    {
        public IEnumerable<ProjectViewModel> CollectionProject { get; set; }

        public CollectionProjectViewModel(IEnumerable<ProjectEntity> collection)
        {
            CollectionProject = collection.Select(x => new ProjectViewModel(x.Id, x.Name));
        }
    }
}
