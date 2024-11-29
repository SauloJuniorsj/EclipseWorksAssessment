namespace EclipseWorksAssessment.Domain.Entities
{
    public sealed class ProjectEntity : BaseEntity
    {
        public ProjectEntity(string name, List<TaskEntity> tasks)
        {
            Name = name;
            Tasks = tasks;
        }

        public string Name { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }
}
