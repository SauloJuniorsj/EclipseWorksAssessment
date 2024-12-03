using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Enums;

namespace EclipseWorksAssessment.Application.InputModels
{
    public class CreateProjectInputModel
    {
        public string Name { get; set; }
        public int UserId { get; set; }

    }
}
