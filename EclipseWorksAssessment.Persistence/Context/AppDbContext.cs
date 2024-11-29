using EclipseWorksAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
