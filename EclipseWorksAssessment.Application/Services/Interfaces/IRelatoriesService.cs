using EclipseWorksAssessment.Application.ViewModels;

namespace EclipseWorksAssessment.Application.Services.Interfaces
{
    public interface IRelatoriesService
    {
        Task<List<UserTaskPerformanceViewModel>> GenerateUserTaskPerformanceReport();
    }
}
