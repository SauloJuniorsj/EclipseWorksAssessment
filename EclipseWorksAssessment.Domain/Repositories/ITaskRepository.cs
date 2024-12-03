using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskEntity>> GetAllTasks(string query, int projectId);
        Task<TaskEntity> GetTaskById(int taskId, bool asNoTracking = false);
        Task<int> CreateTask(TaskEntity createModel);
        Task<int> Update(TaskEntity updateModel);
        Task<int> Delete(int taskId);
    }
}
