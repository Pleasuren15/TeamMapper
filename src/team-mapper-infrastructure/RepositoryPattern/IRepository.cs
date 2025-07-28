using Microsoft.EntityFrameworkCore;

namespace team_mapper_infrastructure.RepositoryPattern;
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(Guid correlationId);
    Task<T> GetByIdAsync(Guid id, Guid correlationId);
    Task<EntityState> AddAsync(T entity, Guid correlationId);
    Task<EntityState> UpdateAsync(T entity, Guid correlationId);
    Task<EntityState> DeleteAsync(T entity, Guid correlationId);
    Task SaveChangesAsync(Guid correlationId);
}
