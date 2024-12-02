using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.ViewModels;

namespace EclipseWorksAssessment.Application.Services.Interfaces
{
    public interface ITaskService
    {
        List<TaskViewModel> GetAllTasks(string query);
        TaskViewModel GetTaskById(int taskId);
        int Create(CreateTaskInputModel createModel);
        int CreateComment(CreateCommentInputModel createModel);
        void Update(UpdateTaskInputModel updateModel);
        void Delete(int taskId);
    }
}
