using Microsoft.EntityFrameworkCore;

namespace team_mapper_infrastructure.RepositoryPattern;

public class Repository<T>(DbContext context) : IRepository<T> where T : class
{
    protected readonly DbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        _ = await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _ = _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _ = _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        _ = await _context.SaveChangesAsync();
    }
}
