﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using team_mapper_infrastructure.Infrastructure;

namespace team_mapper_infrastructure.RepositoryPattern;

public class Repository<T>(ApplicationDbContext context, ILogger<Repository<T>> logger) : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();
    private readonly ILogger<Repository<T>> _logger = logger;

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        _logger.LogInformation("GetAllAsync Start");
        var results = await _dbSet.ToListAsync();
        _logger.LogInformation("GetAllAsync End: Count {@Count}", results.Count);
        return results;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var results = await _dbSet.FindAsync(id);
        return results!;
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
