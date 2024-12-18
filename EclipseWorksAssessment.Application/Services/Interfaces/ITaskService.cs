﻿using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.ViewModels;

namespace EclipseWorksAssessment.Application.Services.Interfaces
{
    public interface ITaskService
    {
        Task<CollectionTasksViewModel> GetAllTasks(string query, int projectId);
        Task<TaskViewModel> GetTaskById(int taskId, bool asNoTracking = false);
        Task<int> CreateTask(CreateTaskInputModel createModel);
        Task<int> CreateComment(CreateCommentInputModel createModel);
        Task<int> Update(UpdateTaskInputModel updateModel);
        Task<int> Delete(int taskId);
    }
}
