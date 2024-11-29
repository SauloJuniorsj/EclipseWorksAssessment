using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.Services.Interfaces;
using EclipseWorksAssessment.Application.ViewModels;
using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Persistence.Context;

namespace EclipseWorksAssessment.Application.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _dbContext;

        public TaskService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid Create(CreateTaskInputModel createModel)
        {
            TaskEntity task = new TaskEntity(
                createModel.Title,
                createModel.Description,
                createModel.DueDate,
                createModel.Status,
                createModel.Priority,
                createModel.ProjectId
                );

            _dbContext.Tasks.Add(task);

            return task.Id;
        }

        public Guid CreateComment(CreateCommentInputModel createModel)
        {
            UserCommentEntity comment = new UserCommentEntity(
                createModel.HistoryType,
                createModel.TaskId,
                createModel.Changes,
                createModel.Comment,
                createModel.ModifiedBy,
                createModel.UserId
                );

            _dbContext.UserComments.Add(comment);

            return comment.Id;
        }

        public void Delete(Guid taskId)
        {
            var task = _dbContext.Tasks.Find(taskId);
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
            }
        }

        public List<TaskViewModel> GetAllTasks(string query)
        {
            var tasks = _dbContext.Tasks;

            var tasksViewModel = tasks
                .Select(t => new TaskViewModel(
                    t.Id,
                    t.Title,
                    t.Description,
                    t.DueDate,
                    t.Status,
                    t.Priority,
                    t.ProjectId
                    ))
                .ToList();

            return tasksViewModel;

        }

        public TaskViewModel GetTaskById(Guid taskId)
        {
            var task = _dbContext.Tasks.SingleOrDefault(x => x.Id == taskId);

            var taskViewModel = new TaskViewModel(
                task.Id,
                task.Title,
                task.Description,
                task.DueDate, 
                task.Status,
                task.Priority,
                task.ProjectId
                );

            return taskViewModel;
        }

        public void Update(UpdateTaskInputModel updateModel)
        {
         
            var task = _dbContext.Tasks.SingleOrDefault(x => x.Id == updateModel.Id);
            
            task.UpdateTask(updateModel.Title, updateModel.Description, updateModel.DueDate, updateModel.Status);

        }
    }
}
