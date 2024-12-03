using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Application.Services.Interfaces
{
    public interface IUserCommentService
    {
        Task<int> CreateCommentary(CreateCommentInputModel createModel);
        Task<int> SaveTaskHistoryAsync(CreateCommentInputModel updatedTask);
    }
}
