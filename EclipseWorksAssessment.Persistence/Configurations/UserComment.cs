using EclipseWorksAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorksAssessment.Persistence.Configurations
{
    public class UserComment : IEntityTypeConfiguration<UserCommentEntity>
    {
        public void Configure(EntityTypeBuilder<UserCommentEntity> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Task)
                .WithMany(x => x.UserComments)
                .HasForeignKey(x => x.TaskId);
        }
    }
}
