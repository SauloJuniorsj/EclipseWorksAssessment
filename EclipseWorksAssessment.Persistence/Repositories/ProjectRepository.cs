using EclipseWorksAssessment.Domain.Entities;
using EclipseWorksAssessment.Domain.Exceptions;
using EclipseWorksAssessment.Domain.Repositories;
using EclipseWorksAssessment.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EclipseWorksAssessment.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        protected readonly AppDbContext _db;

        public ProjectRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<int> Create(ProjectEntity model)
        {
            try
            {
                _db.Projects.Add(model);

                await _db.SaveChangesAsync();

                return model.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar projeto", ex);
            }
        }

        public async Task<int> Delete(int projectId)
        {
            try
            {
                var project = await GetById(projectId);

                if (project == null)
                {
                    throw new KeyNotFoundException($"Projeto com o ID {projectId} não encontrado.");
                }

                if (project.Tasks.Any(x => x.Status == 0))
                {
                    throw new DomainLogicException(ErrorConstants.ProjectHavePendingTask);
                }

                _db.Projects.Remove(project);

                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }

        public async Task<List<ProjectEntity>> GetAll(int userId)
        {
            return await _db.Projects
                .Include(x => x.Tasks)
                .Include(x => x.User)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<ProjectEntity> GetById(int id)
        {
            try
            {
                var project = await _db.Projects
                        .Include(x => x.Tasks)
                        .Include(x => x.User)
                        .FirstOrDefaultAsync(x => x.Id == id);

                if (project is null)
                {
                    throw new KeyNotFoundException($"Projeto com Id {id} não encontrado.");
                }

                return project;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
