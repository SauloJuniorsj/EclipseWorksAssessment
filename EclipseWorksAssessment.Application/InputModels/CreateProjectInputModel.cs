using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Application.InputModels
{
    public class CreateProjectInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
