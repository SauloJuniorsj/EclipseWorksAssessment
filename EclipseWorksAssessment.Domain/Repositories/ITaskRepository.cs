using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Domain.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEntity>> GetAllTasks(string query, int projectId);
        Task<TaskEntity> GetTaskById(int taskId);
        Task<int> CreateTask(TaskEntity createModel);
        Task<int> CreateComment(UserCommentEntity createModel);
        Task<int> Update(TaskEntity updateModel);
        Task<int> Delete(int taskId);
    }
}
