using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Repositories;
using EclipseWorksAssessment.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EclipseWorksAssessment.Persistence.Repositories
{
    public class UserCommentRepository : IUserCommentRepository
    {
        private readonly AppDbContext _db;
        public UserCommentRepository(AppDbContext context)
        {
            _db = context;
        }
        public async Task<int> AddAsync(UserCommentEntity userComment)
        {
            try
            {
                using (_db)
                {
                    _db.UserComments.Add(userComment);

                    return await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar comentário", ex);
            }
        }
        //public async Task SaveTaskHistoryAsync(TaskEntity oldTask, TaskEntity updatedTask, string modifiedBy)
        //{
        //    var history = new TaskHistory
        //    {
        //        TaskId = oldTask.Id,
        //        OldState = JsonConvert.SerializeObject(oldTask), // Salva o estado anterior
        //        NewState = JsonConvert.SerializeObject(updatedTask), // Salva o estado atualizado
        //        ModifiedBy = modifiedBy,
        //        ModifiedAt = DateTime.UtcNow
        //    };

        //    await _context.TaskHistories.AddAsync(history);
        //    await _context.SaveChangesAsync();
        //}
    }
}
