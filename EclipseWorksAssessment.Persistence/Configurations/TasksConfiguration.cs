using EclipseWorksAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorksAssessment.Persistence.Configurations
{
    public class TasksConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Title)
                .HasMaxLength(100);

            builder
                .HasOne(x => x.Project)                
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.ProjectId);

            builder
                .HasMany(x => x.UserComments);
        }   
    }
}
