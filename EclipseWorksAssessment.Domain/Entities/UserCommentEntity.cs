using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Domain.Entities
{
    public class UserCommentEntity : BaseEntity
    {
        public UserCommentEntity(EHistoryType historyType, int taskId, int userId, string oldState, string newState, DateTime modifiedAt)
        {
            HistoryType = historyType;
            TaskId = taskId;
            UserId = userId;
            OldState = oldState;
            NewState = newState;
            ModifiedAt = modifiedAt;
        }
        public UserCommentEntity(EHistoryType historyType, int taskId, int userId, string comment)
        {
            HistoryType = historyType;
            TaskId = taskId;
            UserId = userId;
            Comment = comment;
        }

        public EHistoryType HistoryType { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string OldState { get; set; }
        public string NewState { get; set; }
        public string Comment { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual TaskEntity Task { get; set; }
    }
}
