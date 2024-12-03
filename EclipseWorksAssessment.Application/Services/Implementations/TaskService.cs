using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.Services.Interfaces;
using EclipseWorksAssessment.Application.ViewModels;
using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Repositories;

namespace EclipseWorksAssessment.Application.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserCommentRepository _userComment;

        public TaskService(ITaskRepository taskRepository, IUserCommentRepository userComment)
        {
            _taskRepository = taskRepository;
            _userComment = userComment;
        }

        public async Task<int> CreateTask(CreateTaskInputModel createModel)
        {
            TaskEntity task = new TaskEntity(
                createModel.Title,
                createModel.Description,
                createModel.DueDate,
                createModel.Status,
                createModel.Priority,
                createModel.ProjectId
                );

            await _taskRepository.CreateTask(task);

            return task.Id;
        }

        public async Task<int> CreateComment(CreateCommentInputModel createModel)
        {
            UserCommentEntity comment = new UserCommentEntity(
                createModel.HistoryType,
                createModel.TaskId,
                createModel.UserId,
                createModel.Comment
                );

            await _taskRepository.CreateComment(comment);

            return comment.Id;
        }

        public async Task<int> Delete(int taskId)
        {
            return await _taskRepository.Delete(taskId);
        }

        public async Task<CollectionTasksViewModel> GetAllTasks(string query, int projectId)
        {
            var tasks = await _taskRepository.GetAllTasks(query, projectId);
            var taskViewModels = new CollectionTasksViewModel(tasks);
            return taskViewModels;
        }

        public async Task<TaskViewModel> GetTaskById(int taskId)
        {
            var task = await _taskRepository.GetTaskById(taskId);

            if (task == null) return null;

            return new TaskViewModel(task.Id, task.Title, task.Description, task.DueDate, task.Status, task.Priority, task.ProjectId);
        }

        public async Task<int> Update(UpdateTaskInputModel updateModel)
        {
            TaskEntity newTask = new TaskEntity(
                updateModel.Id,
                updateModel.Title,
                updateModel.Description,
                updateModel.DueDate,
                updateModel.Status,
                updateModel.ProjectId
                );

            var oldModel = GetTaskById(updateModel.Id);

            UserCommentEntity userCommentEntity = new UserCommentEntity(
                Domain.Enums.EHistoryType.Update,
                newTask.Id,
                updateModel.UserId,
                string.Empty,
                string.Empty,
                //JsonConvert.SerializeObject(oldModel),
                //JsonConvert.SerializeObject(newTask),
                DateTime.UtcNow
                );

            await _userComment.SaveTaskHistoryAsync(userCommentEntity);

            return await _taskRepository.Update(newTask);
        }
    }
}
