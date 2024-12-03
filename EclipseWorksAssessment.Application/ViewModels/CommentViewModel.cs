using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Application.ViewModels
{
    public class CommentViewModel
    {
        public CommentViewModel()
        {
            
        }
        public CommentViewModel(EHistoryType historyType, string changes, string comment, string modifiedBy, TaskViewModel task)
        {
            HistoryType = historyType;
            Changes = changes;
            Comment = comment;
            ModifiedBy = modifiedBy;
            Task = task;
        }

        public EHistoryType HistoryType { get; set; }
        public string Changes { get; set; }
        public string Comment { get; set; }
        public string ModifiedBy { get; set; }
        public TaskViewModel Task { get; set; }
    }
}
