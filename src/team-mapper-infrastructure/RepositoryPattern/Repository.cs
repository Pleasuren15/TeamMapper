using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using team_mapper_infrastructure.Infrastructure;
using team_mapper_infrastructure.Interfaces;

namespace team_mapper_infrastructure.RepositoryPattern;

public class Repository<T>(
    ApplicationDbContext context,
    IPollyPolicyWrapper pollyPolicyWrapper,
    ILogger<Repository<T>> logger) : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();
    private readonly IPollyPolicyWrapper _pollyPolicyWrapper = pollyPolicyWrapper;
    private readonly ILogger<Repository<T>> _logger = logger;

    public async Task<IEnumerable<T>> GetAllAsync(Guid correlationId)
    {
        _logger.LogInformation("GetAllAsync(Repository) Start: CorrelationId {@CorrelationId}", correlationId);

        var results = await _pollyPolicyWrapper.ExecuteWithPollyRetryPolicyAsync<Exception, IEnumerable<T>>(
            async () => await _dbSet.AsNoTracking()
                                    .ToListAsync<T>());

        _logger.LogInformation("GetAllAsync(Repository) End: CorrelationId {@CorrelationId} Count {@Count}", correlationId, results.Count());
        return results;
    }

    public async Task<T> GetByIdAsync(Guid id, Guid correlationId)
    {
        var results = await _dbSet.FindAsync(id);
        return results!;
    }

    public async Task<EntityState> AddAsync(T entity, Guid correlationId)
    {
        _logger.LogInformation("AddAsync(Repository) Start: Entity {@entity} CorrelationId {@CorrelationId}", entity, correlationId);

        var results = await _pollyPolicyWrapper.ExecuteWithPollyRetryPolicyAsync<Exception, EntityEntry<T>>(
                async () => await _dbSet.AddAsync(entity));

        _logger.LogInformation("AddAsync(Repository) End: Entity {@entity} CorrelationId {@CorrelationId}", entity, correlationId);
        return results.State;
    }

    public async Task<EntityState> UpdateAsync(T entity, Guid correlationId)
    {
        _logger.LogInformation("UpdateAsync(Repository) Start: Entity {@entity} CorrelationId {@CorrelationId}", entity, correlationId);

        var state = await DeleteAsync(entity, correlationId);
        await SaveChangesAsync(correlationId);
        if (state is EntityState.Deleted)
        {
            state = await AddAsync(entity: entity, correlationId: correlationId);
        }

        _logger.LogInformation("UpdateAsync(Repository) End: Entity {@entity} CorrelationId {@CorrelationId}", entity, correlationId);
        return state;
    }

    public async Task<EntityState> DeleteAsync(T entity, Guid correlationId)
    {
        _logger.LogInformation("DeleteAsync(Repository) Start: Entity {@entity} CorrelationId {@CorrelationId}", entity, correlationId);

        var results = await _pollyPolicyWrapper.ExecuteWithPollyRetryPolicyAsync<Exception, EntityEntry<T>>(async () => _dbSet.Remove(entity));

        _logger.LogInformation("DeleteAsync(Repository) End: Entity {@entity} CorrelationId {@CorrelationId}", entity, correlationId);
        return results.State;
    }

    public async Task SaveChangesAsync(Guid correlationId)
    {
        _logger.LogInformation("SaveChangesAsync(Repository) Start: CorrelationId {@CorrelationId}", correlationId);
        await _context.SaveChangesAsync();
        _logger.LogInformation("SaveChangesAsync(Repository) End: CorrelationId {@CorrelationId}", correlationId);
    }
}
