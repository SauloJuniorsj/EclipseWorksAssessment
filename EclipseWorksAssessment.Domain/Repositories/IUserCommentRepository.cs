using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Domain.Repositories
{
    public interface IUserCommentRepository
    {
        Task<int> CreateCommentary(UserCommentEntity userComment);
        Task<int> SaveTaskHistoryAsync(UserCommentEntity updatedTask);
    }
}
