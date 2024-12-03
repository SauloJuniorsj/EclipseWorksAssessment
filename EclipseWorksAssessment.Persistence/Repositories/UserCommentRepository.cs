using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Repositories;
using EclipseWorksAssessment.Persistence.Context;

namespace EclipseWorksAssessment.Persistence.Repositories
{
    public class UserCommentRepository : IUserCommentRepository
    {
        private readonly AppDbContext _db;
        public UserCommentRepository(AppDbContext context)
        {
            _db = context;
        }
        public async Task<int> CreateCommentary(UserCommentEntity userComment)
        {
            try
            {
                _db.UserComments.Add(userComment);

                return await _db.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar comentário", ex);
            }
        }

        public async Task<int> SaveTaskHistoryAsync(UserCommentEntity updatedTask)
        {
            try
            {
                _db.UserComments.Add(updatedTask);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }
    }
}
