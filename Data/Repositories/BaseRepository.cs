using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();



    // Create
    public virtual async Task<bool> AddAsync(TEntity entity)
    {
        try
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }


    // Read
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities;
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(expression);
        return entity;
    }


    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        var exists = await _dbSet.AnyAsync(expression);
        return exists;
    }


    // Update
    public virtual async Task<bool> UpdateAsync(TEntity entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }


    // Delete
    public virtual async Task<bool> RemoveAsync(TEntity entity)
    {
        try
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
