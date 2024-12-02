
using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Repositories;
using EclipseWorksAssessment.Persistence.Context;

namespace EclipseWorksAssessment.Persistence.Repositories
{
    public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context)
        { }

    }
}
