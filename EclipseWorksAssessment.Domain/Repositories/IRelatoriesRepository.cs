using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Domain.Repositories
{
    public interface IRelatoriesRepository
    {
        Task<List<ProjectEntity>> GetCompletedTasksByUserInLast30Days();
    }
}
