using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.Services.Interfaces;
using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Enums;
using EclipseWorksAssessment.Domain.Exceptions;
using EclipseWorksAssessment.Domain.Repositories;
using Newtonsoft.Json;

namespace EclipseWorksAssessment.Application.Services.Implementations
{
    public class UserCommentService : IUserCommentService
    {
        private readonly IUserCommentRepository _userCommentRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public UserCommentService(IUserCommentRepository userCommentRepository, ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _userCommentRepository = userCommentRepository;
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public async Task<int> CreateCommentary(CreateUserCommentInputModel createModel)
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
                JsonConvert.SerializeObject(oldTask),
                JsonConvert.SerializeObject(updatedTask),
                DateTime.UtcNow,
                updatedTask.Comment
            );

           return await _userCommentRepository.SaveTaskHistoryAsync(history);
        }
    }
}
