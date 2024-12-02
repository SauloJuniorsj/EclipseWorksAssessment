using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.ViewModels;

namespace EclipseWorksAssessment.Application.Services.Interfaces
{
    public interface ITaskService
    {
        Task<CollectionTasksViewModel> GetAllTasks(string query);
        Task<TaskViewModel> GetTaskById(int taskId);
        Task<int> CreateTask(CreateTaskInputModel createModel);
        Task<int> CreateComment(CreateCommentInputModel createModel);
        Task<int> Update(UpdateTaskInputModel updateModel);
        Task<int> Delete(int taskId);
    }
}
