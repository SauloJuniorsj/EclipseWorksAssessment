using EclipseWorksAssessment.Application.Services.Interfaces;
using EclipseWorksAssessment.Application.ViewModels;
using EclipseWorksAssessment.Domain.Repositories;

namespace EclipseWorksAssessment.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> GetById(int userId)
        {
            var user = await _userRepository.GetById(userId);

            if (user == null) return null;

            return new UserViewModel(user.Id, user.Name, user.UserHierarchy);

        }
    }
}
