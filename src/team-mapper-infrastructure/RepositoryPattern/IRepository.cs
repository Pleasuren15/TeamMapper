using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace team_mapper_infrastructure.RepositoryPattern;
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(Guid correlationId);
    Task<T> GetByIdAsync(Guid id, Guid correlationId);
    Task<EntityEntry<T>> AddAsync(T entity, Guid correlationId);
    void Update(T entity, Guid correlationId);
    void Delete(T entity, Guid correlationId);
    Task SaveChangesAsync(Guid correlationId);
}
