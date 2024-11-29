using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.ViewModels;

namespace EclipseWorksAssessment.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll();
        ProjectViewModel GetById(Guid id);
        Guid Create(CreateProjectInputModel model);
    }
}
