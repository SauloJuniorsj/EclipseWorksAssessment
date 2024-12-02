using EclipseWorksAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorksAssessment.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.
                HasKey(x => x.Id);

            builder.
                Property(x => x.Name).
                HasMaxLength(100);

            builder.
                HasOne(x => x.User).
                WithMany(x => x.UserProjects).
                HasForeignKey(x => x.UserId);

            builder.
                HasMany(x => x.Tasks).
                WithOne(x => x.Project).
                HasForeignKey(x => x.ProjectId);
        }
    }
}
