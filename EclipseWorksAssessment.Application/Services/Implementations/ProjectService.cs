using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.Services.Interfaces;
using EclipseWorksAssessment.Application.ViewModels;
using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Repositories;

namespace EclipseWorksAssessment.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> Create(CreateProjectInputModel model)
        {
            ProjectEntity project = new ProjectEntity(
               model.Name,
               model.UserId
            );

            await _projectRepository.Create(project);

            return project.Id;
        }

        public async Task<int> Delete(int projectId)
        {
            return await _projectRepository.Delete(projectId);
        }

        public async Task<CollectionProjectViewModel> GetAll(int userId)
        {
            var proj = await _projectRepository.GetAll(userId);
            var projViewModels = new CollectionProjectViewModel(proj);
            return projViewModels;
        }

        public async Task<ProjectViewModel> GetById(int id)
        {
            var project = await _projectRepository.GetById(id);
            if (project == null) return null;

            return new ProjectViewModel(project);
        }
    }
}
