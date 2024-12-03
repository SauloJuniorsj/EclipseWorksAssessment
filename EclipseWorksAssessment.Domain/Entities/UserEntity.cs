using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity(string name)
        {
            Name = name;
            UserProjects = new List<ProjectEntity>();
        }

        //public UserEntity(string name, EUserHierarchy userHierarchy)
        //{
        //    Name = name;
        //    UserHierarchy = userHierarchy;
        //    UserProjects = new List<ProjectEntity>();
        //}


        public string Name { get; set; }
        public EUserHierarchy UserHierarchy{ get; set; }
        public virtual List<ProjectEntity> UserProjects { get; set; }
        public virtual List<UserCommentEntity> UserComments { get; set; }
    }
}
