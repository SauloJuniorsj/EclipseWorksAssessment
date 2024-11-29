using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.Services.Interfaces;
using EclipseWorksAssessment.Application.ViewModels;
using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EclipseWorksAssessment.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _dbContext;

        public ProjectService(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public Guid Create(CreateProjectInputModel model)
        {
            ProjectEntity project = new ProjectEntity(
               model.Name,
               model.Tasks
            );

            _dbContext.Projects.Add(project);

            return project.Id;
        }

        public List<ProjectViewModel> GetAll()
        {
            var projects = _dbContext.Projects.Include(x => x.Tasks).ToList();

            return projects.Select(x => new ProjectViewModel(x.Id, x.Name)).ToList();
        }

        public ProjectViewModel GetById(Guid id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            
            if (project == null) return null;

            return new ProjectViewModel(project.Id, project.Name);
        }
    }
}
