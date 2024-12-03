using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<List<ProjectEntity>> GetAll(int userId);
        Task<int> Create(ProjectEntity model);
        Task<int> Delete(int projectId);
        Task<ProjectEntity> GetById(int id);
    }
}
