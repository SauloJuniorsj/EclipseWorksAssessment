using EclipseWorksAssessment.Application.ViewModels;
using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Repositories;

namespace EclipseWorksAssessment.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetById(int userId);
    }
}
