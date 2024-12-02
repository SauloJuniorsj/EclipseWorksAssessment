using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Domain.Repositories
{
    public interface IUserCommentRepository
    {
        Task<int> AddAsync(UserCommentEntity userComment);
    }
}
