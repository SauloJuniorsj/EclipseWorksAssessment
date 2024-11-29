using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.ViewModels;

namespace EclipseWorksAssessment.Application.Services.Interfaces
{
    public interface ITaskService
    {
        List<TaskViewModel> GetAllTasks(string query);
        TaskViewModel GetTaskById(Guid taskId);
        Guid Create(CreateTaskInputModel createModel);
        Guid CreateComment(CreateCommentInputModel createModel);
        void Update(UpdateTaskInputModel updateModel);
        void Delete(Guid taskId);
    }
}
