using EclipseWorksAssessment.Application.Services.Interfaces;
using EclipseWorksAssessment.Application.ViewModels;
using EclipseWorksAssessment.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorksAssessment.Application.Services.Implementations
{
    public class RelatoriesService : IRelatoriesService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRelatoriesRepository _relatories;

        public RelatoriesService(IUserRepository userRepository, IRelatoriesRepository relatoriesRepository)
        {
            _userRepository = userRepository;
            _relatories = relatoriesRepository;
        }
        public async Task<List<UserTaskPerformanceViewModel>> GenerateUserTaskPerformanceReport()
        {
            var users = await _userRepository.GetAll();
            var reportData = new List<UserTaskPerformanceViewModel>();

            foreach (var user in users)
            {
                var completedTasks = await _relatories.GetCompletedTasksByUserInLast30Days();
                reportData.Add(new UserTaskPerformanceViewModel
                {
                    UserName = user.Name,
                    CompletedTasks = completedTasks.Count,
                    AverageCompletedTasks = completedTasks.Count / 30.0
                });
            }

            return reportData;
        }

    }
}
