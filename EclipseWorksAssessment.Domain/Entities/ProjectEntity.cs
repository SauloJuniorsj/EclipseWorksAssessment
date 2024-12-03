using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Domain.Entities
{
    public class ProjectEntity : BaseEntity
    {
        public ProjectEntity(string name, int userId)
        {
            Name = name;
            UserId = userId;
            Tasks = new List<TaskEntity>();
        }

        public string Name { get; set; }
        public int UserId { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual List<TaskEntity> Tasks { get; set; }
    }
}
