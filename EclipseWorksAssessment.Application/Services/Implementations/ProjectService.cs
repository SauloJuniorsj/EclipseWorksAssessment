using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.Services.Interfaces;
using EclipseWorksAssessment.Application.ViewModels;
using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EclipseWorksAssessment.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _dbContext;
        private readonly string _connectionString;

        public ProjectService(AppDbContext appDbContext, IConfiguration configuration)
        {
            _dbContext = appDbContext;
            _connectionString = configuration.GetConnectionString("EclipseWorksCs");
        }

        public int Create(CreateProjectInputModel model)
        {
            ProjectEntity project = new ProjectEntity(
               model.Name
            );

            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();

            return project.Id;
        }

        public List<ProjectViewModel> GetAll()
        {
            var projects = _dbContext.Projects
                .Include(x => x.Tasks)
                .Include(x => x.User).ToList();

            return projects.Select(x => new ProjectViewModel(x.Id, x.Name)).ToList();
        }

        public ProjectViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(x => x.Tasks)
                .Include(x => x.User)
                .SingleOrDefault(x => x.Id == id);

            if (project == null) return null;

            return new ProjectViewModel(project.Id, project.Name);
        }
    }
}
