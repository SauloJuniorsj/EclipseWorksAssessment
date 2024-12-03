namespace EclipseWorksAssessment.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity(string name)
        {
            Name = name;
            UserProjects = new List<ProjectEntity>();
        }

        public string Name { get; set; }

        public virtual List<ProjectEntity> UserProjects { get; set; }
        public virtual List<UserCommentEntity> UserComments { get; set; }
    }
}
