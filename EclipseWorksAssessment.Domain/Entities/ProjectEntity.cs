namespace EclipseWorksAssessment.Domain.Entities
{
    public class ProjectEntity : BaseEntity
    {
        public ProjectEntity(string name)
        {
            Name = name;
            Tasks = new List<TaskEntity>();
        }

        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual List<TaskEntity> Tasks { get; set; }
    }
}
