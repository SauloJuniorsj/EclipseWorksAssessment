namespace EclipseWorksAssessment.Domain.Exceptions
{
    public class ProjectHaveTaksException: Exception
    {
        public ProjectHaveTaksException() : base("The project still have pending tasks!") { }
    }
}
