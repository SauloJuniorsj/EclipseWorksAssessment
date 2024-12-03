using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Repositories;
using EclipseWorksAssessment.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EclipseWorksAssessment.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext context)
        {
            _db = context;
        }
        public async Task<UserEntity> GetById(int userId)
        {
            try
            {
                var user = await _db.Users
                    .Include(x => x.UserProjects)
                        .FirstOrDefaultAsync(x => x.Id == userId);

                if (user is null)
                {
                    throw new KeyNotFoundException($"Usuário com Id {userId} não encontrado.");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
