using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.Services.Interfaces;
using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Repositories;

namespace EclipseWorksAssessment.Application.Services.Implementations
{
    public class UserCommentService : IUserCommentService
    {
        private readonly IUserCommentRepository _userCommentRepository;
        private readonly ITaskRepository _taskRepository;
        public UserCommentService(IUserCommentRepository userCommentRepository, ITaskRepository taskRepository)
        {
            _userCommentRepository = userCommentRepository;
            _taskRepository = taskRepository;
        }

        public async Task<int> CreateCommentary(CreateCommentInputModel createModel)
        {
            UserCommentEntity comment = new UserCommentEntity(
                createModel.HistoryType,
                createModel.TaskId,
                createModel.UserId,
                createModel.Comment
                );

            return await _userCommentRepository.CreateCommentary(comment);
        }
        public async Task<int> SaveTaskHistoryAsync(CreateCommentInputModel updatedTask)
        {
            var oldTask = await _taskRepository.GetTaskById(updatedTask.TaskId);

            var history = new UserCommentEntity(
                updatedTask.HistoryType,
                oldTask.Id,
                updatedTask.UserId,
                string.Empty,
                string.Empty,
                //JsonConvert.SerializeObject(oldTask),
                //JsonConvert.SerializeObject(updatedTask),
                DateTime.UtcNow
            );

           return await _userCommentRepository.SaveTaskHistoryAsync(history);
        }
    }
}
