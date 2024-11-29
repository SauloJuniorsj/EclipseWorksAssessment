namespace EclipseWorksAssessment.Domain.Entities
{
    public sealed class TaskEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public int ProjectId { get; set; }
        public ProjectEntity Project { get; set; }
    }
}
