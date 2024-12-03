using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.ViewModels;
using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Application.Services.Interfaces
{
    public interface IProjectService
    {
        Task<CollectionProjectViewModel> GetAll(int userId);
        Task<int> Delete(int projectId);
        Task<int> Create(CreateProjectInputModel model);
        Task<ProjectViewModel> GetById(int id);
    }
}
