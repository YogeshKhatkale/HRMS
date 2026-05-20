using HRMS.Application.Interfaces;
using HRMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly HRMSDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(HRMSDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity != null;
    }
}