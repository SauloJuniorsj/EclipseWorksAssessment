using EclipseWorksAssessment.Domain.Entities;

namespace EclipseWorksAssessment.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
