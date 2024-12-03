namespace EclipseWorksAssessment.Domain.Exceptions
{
    public class ErrorConstants
    {
        public const string TaskLimitExceeded = "The maximum number of tasks has been reached";
        public const string ProjectHavePendingTask = "The project still have pending tasks! Finish the tasks before deleting the project";
        public const string UserNotManagerTryDeleteProject = "User does not have permission to delete project";
    }
}
