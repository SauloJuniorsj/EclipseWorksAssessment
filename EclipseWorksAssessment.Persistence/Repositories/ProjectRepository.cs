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

        public ProjectRepository()
        {
        }

        public ProjectRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<int> Create(ProjectEntity model)
        {
            try
            {
                using (_db)
                {
                    _db.Projects.Add(model);

                    await _db.SaveChangesAsync();

                    return model.Id;
                }
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
                using (_db)
                {
                    var project = _db.Projects.FirstOrDefault(x => x.Id == projectId);
                    if (project == null)
                    {
                        throw new KeyNotFoundException($"Projeto com o ID {projectId} não encontrado.");
                    }

                    if (project.Tasks.Any())
                    {
                        throw new ProjectHaveTaksException();
                    }

                    _db.Projects.Remove(project);

                    return await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<ProjectEntity>> GetAll(int userId)
        {
            using (_db)
            {
                return await _db.Projects
                    .Where(x => x.UserId == userId)
                    .ToListAsync();
            }
        }

        public async Task<ProjectEntity> GetById(int id)
        {
            using (_db)
            {
                return await _db.Projects
                    .Include(x => x.Tasks)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}
