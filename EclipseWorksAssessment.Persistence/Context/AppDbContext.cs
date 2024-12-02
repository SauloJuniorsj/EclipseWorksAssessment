using EclipseWorksAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EclipseWorksAssessment.Persistence.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<TaskEntity> Tasks{ get; set; }
        public DbSet<UserEntity> Users{ get; set; }
        public DbSet<UserCommentEntity> UserComments{ get; set; }

    }
}
