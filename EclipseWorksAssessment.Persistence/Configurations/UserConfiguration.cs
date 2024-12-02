using EclipseWorksAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorksAssessment.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.UserProjects)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
