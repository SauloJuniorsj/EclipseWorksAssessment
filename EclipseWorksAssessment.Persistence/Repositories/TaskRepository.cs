
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

        public async Task<int> CreateTask(TaskEntity createModel)
        {
            var project = await _db.Projects
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.Id == createModel.ProjectId);

            if (project == null)
            {
                throw new KeyNotFoundException($"Tarefa com o ID {createModel.ProjectId} não encontrado.");
            }
            if (project.Tasks.Count >= 20)
            {
                throw new DomainLogicException(ErrorConstants.TaskLimitExceeded);
            }

            try
            {
                _db.Tasks.Add(createModel);

                await _db.SaveChangesAsync();

                return createModel.Id;
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
                var task = await _db.Tasks.FirstOrDefaultAsync(x => x.Id == taskId);
                if (task == null)
                {
                    throw new KeyNotFoundException($"Task com o ID {taskId} não encontrado.");
                }

                _db.Tasks.Remove(task);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }

        public async Task<List<TaskEntity>> GetAllTasks(string query, int projectId)
        {
            return await _db.Tasks
                    .Include(x => x.UserComments)
                    .Include(x => x.Project)
                    .Where(x => x.ProjectId == projectId)
                    .ToListAsync();
        }

        public async Task<TaskEntity> GetTaskById(int taskId, bool asNoTracking)
        {
            try
            {
                var query = _db.Tasks
                .Include(x => x.UserComments)
                .Include(x => x.Project)
                .AsQueryable();

                if (asNoTracking)
                {
                    query = query.AsNoTracking();
                }
                var task = await query.FirstOrDefaultAsync(x => x.Id == taskId);

                if (task is null)
                {
                    throw new KeyNotFoundException($"Tarefa com Id {taskId} não encontrado.");
                }

                return task;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> Update(TaskEntity entity)
        {
            try
            {
                var trackedEntity = _db.Tasks.Local.FirstOrDefault(x => x.Id == entity.Id);
                if (trackedEntity != null)
                {
                    _db.Entry(trackedEntity).State = EntityState.Detached;
                }
                _db.Tasks.Update(entity);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao atualizar task", ex);
            }
        }
    }
}
