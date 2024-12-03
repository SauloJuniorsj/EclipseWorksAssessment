using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Enums;
using EclipseWorksAssessment.Domain.Repositories;
using EclipseWorksAssessment.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EclipseWorksAssessment.Persistence.Repositories
{
    public class RelatoriesRepository : IRelatoriesRepository
    {
        private readonly AppDbContext _dbContext;

        public RelatoriesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProjectEntity>> GetCompletedTasksByUserInLast30Days()
        {
            return await _dbContext.Projects
              .Include(x => x.Tasks)
              .Include(x => x.User)
              .Where(p => p.Tasks.Any(t => t.Status == ETaskStatus.Done && t.DueDate >= DateTime.Now.AddDays(-30)))
              .ToListAsync();
        }
    }
}
