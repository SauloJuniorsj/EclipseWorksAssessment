
using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Exceptions;
using EclipseWorksAssessment.Domain.Repositories;
using EclipseWorksAssessment.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EclipseWorksAssessment.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        protected readonly AppDbContext _db;
        public TaskRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<int> CreateComment(UserCommentEntity createModel)
        {
            try
            {
                using (_db)
                {
                    _db.UserComments.Add(createModel);

                    await _db.SaveChangesAsync();

                    return createModel.Id;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar Comentário", ex);
            }
        }

        public async Task<int> CreateTask(TaskEntity createModel)
        {
            var project = _db.Projects.FirstOrDefault(x => x.Id == createModel.ProjectId);

            if (project == null)
            {
                throw new KeyNotFoundException($"Projeto com o ID {createModel.ProjectId} não encontrado.");
            }
            if (project.Tasks.Count >= 20)
            {
                throw new TaskLimitExcededException();
            }

            try
            {
                using (_db)
                {
                    _db.Tasks.Add(createModel);

                    await _db.SaveChangesAsync();

                    return createModel.Id;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar task", ex);
            }
        }

        public async Task<int> Delete(int taskId)
        {
            try
            {
                using (_db)
                {
                    var task = _db.Tasks.FirstOrDefault(x => x.Id == taskId);
                    if (task == null)
                    {
                        throw new KeyNotFoundException($"Task com o ID {taskId} não encontrado.");
                    }

                    _db.Tasks.Remove(task);

                    return await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasks(string query, int projectId)
        {
            using (_db)
            {
                return await _db.Tasks
                        .Include(x => x.UserComments)
                        .Where(x => x.ProjectId == projectId)
                        .ToListAsync();
            }
        }

        public async Task<TaskEntity> GetTaskById(int taskId)
        {
            using (_db)
            {
                return await _db.Tasks
                    .Include(x => x.UserComments)
                    .FirstOrDefaultAsync(x => x.Id == taskId);
            }
        }

        public async Task<int> Update(TaskEntity entity)
        {
            var task = _db.Tasks.FirstOrDefault(x => x.Id == entity.Id);

            if (task == null)
            {
                throw new KeyNotFoundException($"Tarefa com o ID {entity.Id} não encontrado.");
            }

            try
            {
                using (_db)
                {
                    _db.Tasks.Update(entity);

                    return await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao atualizar task", ex);
            }
        }
    }
}
