using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Repositories;
using EclipseWorksAssessment.Persistence.Context;
using Microsoft.EntityFrameworkCore;

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
                userComment.DateCreated = DateTime.Now;

                return await _db.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar comentário", ex);
            }
        }
        public async Task<UserCommentEntity> GetById(int id)
        {
            try
            {
                var task = await _db.UserComments
                .Include(x => x.Task)
                .FirstOrDefaultAsync(x => x.Id == id);

                if (task is null)
                {
                    throw new KeyNotFoundException($"Comentário(s) com Id {id} não encontrado.");
                }

                return task;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
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
