namespace EclipseWorksAssessment.Domain.Entities
{
    public sealed class ProjectEntity
    {
        public string Name { get; set; }
        public List<TaskEntity> Tasks { get; set; }
    }
}
