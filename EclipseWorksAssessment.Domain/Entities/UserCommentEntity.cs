﻿using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Domain.Entities
{
    public sealed class UserCommentEntity : BaseEntity
    {
        public UserCommentEntity(EHistoryType historyType, int taskId, string changes, string comment, string modifiedBy, Guid userId)
        {
            HistoryType = historyType;
            TaskId = taskId;
            Changes = changes;
            Comment = comment;
            ModifiedBy = modifiedBy;
            UserId = userId;
        }

        public EHistoryType HistoryType { get; set; }
        public int TaskId { get; set; }
        public Guid UserId { get; set; }
        public string Changes { get; set; }
        public string Comment { get; set; }
        public string ModifiedBy { get; set; }
    }
}
