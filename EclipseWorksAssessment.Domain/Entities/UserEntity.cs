namespace EclipseWorksAssessment.Domain.Entities
{
    public sealed class UserEntity : BaseEntity
    {
        public string Name { get; set; }

        public List<ProjectEntity> UserProjects { get; set; }
    }
}
