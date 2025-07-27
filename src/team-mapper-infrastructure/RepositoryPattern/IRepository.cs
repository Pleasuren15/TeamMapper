using Microsoft.EntityFrameworkCore;

namespace team_mapper_infrastructure.RepositoryPattern;
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(Guid correlationId);
    Task<T> GetByIdAsync(Guid id, Guid correlationId);
    Task<EntityState> AddAsync(T entity, Guid correlationId);
    void Update(T entity, Guid correlationId);
    void Delete(T entity, Guid correlationId);
    Task SaveChangesAsync(Guid correlationId);
}
