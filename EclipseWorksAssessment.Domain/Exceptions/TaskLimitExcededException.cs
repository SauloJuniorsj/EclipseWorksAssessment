namespace EclipseWorksAssessment.Domain.Exceptions
{
    public class TaskLimitExcededException : Exception
    {
        public TaskLimitExcededException() : base("The maximum number of tasks has been reached") { }
    }
}
