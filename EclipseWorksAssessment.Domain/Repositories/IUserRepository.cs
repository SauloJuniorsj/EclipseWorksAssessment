using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetById(int userId);
        Task<List<UserEntity>> GetAll();
    }
}
