using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Repositories;
using EclipseWorksAssessment.Persistence.Context;

namespace EclipseWorksAssessment.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        protected readonly AppDbContext Context;

        public ProjectRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Create(ProjectEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProjectEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProjectEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
