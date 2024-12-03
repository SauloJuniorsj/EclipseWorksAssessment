using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.Services.Interfaces;
using EclipseWorksAssessment.Application.ViewModels;
using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Repositories;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace EclipseWorksAssessment.Application.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserCommentRepository _userComment;
        private readonly IProjectRepository _projectRepository;

        public TaskService(ITaskRepository taskRepository, IUserCommentRepository userComment, IProjectRepository projectRepository)
        {
            _taskRepository = taskRepository;
            _userComment = userComment;
            _projectRepository = projectRepository;
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

            await _userComment.CreateCommentary(comment);

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

        public async Task<TaskViewModel> GetTaskById(int taskId, bool asNoTracking = false)
        {
            var task = await _taskRepository.GetTaskById(taskId, asNoTracking);

            if (task == null) return null;

            return new TaskViewModel(task.Id, task.Title, task.Description, task.DueDate, task.Status, task.Priority, task.ProjectId, task.DateCreated, task.DateDeleted);
        }

        public async Task<int> Update(UpdateTaskInputModel updateModel)
        {
            var oldModel = await GetTaskById(updateModel.Id, true);

            TaskEntity newTask = new TaskEntity(
                updateModel.Id,
                updateModel.Title,
                updateModel.Description,
                updateModel.DueDate,
                updateModel.Status,
                oldModel.Priority,
                oldModel.ProjectId,
                oldModel.DateCreated,
                oldModel.DateDeleted
                );

            await CreateComment(updateModel.Id, oldModel, updateModel, oldModel.ProjectId);

            return await _taskRepository.Update(newTask);
        }

        public async Task<int> CreateComment(int taskId, TaskViewModel oldModel, UpdateTaskInputModel updateModel, int projectId)
        {
            var project = await _projectRepository.GetById(projectId);

            UserCommentEntity userCommentEntity = new UserCommentEntity(
                Domain.Enums.EHistoryType.Update,
                taskId,
                project.UserId,
                JsonConvert.SerializeObject(oldModel),
                JsonConvert.SerializeObject(updateModel),
                DateTime.UtcNow,
                string.Empty
                );

            return await _userComment.SaveTaskHistoryAsync(userCommentEntity);
        }
    }
}
