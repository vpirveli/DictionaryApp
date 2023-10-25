using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data;

public class GenericEFRepository<TEntity> : IGenericEFRepository<TEntity> where TEntity : class
{
    DictionaryDbContext _dbContext;

    public GenericEFRepository(DictionaryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(TEntity entity)
    {
        await _dbContext.AddAsync<TEntity>(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _dbContext.Remove<TEntity>(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        _dbContext.RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<TEntity?> GetByConditionAsync(Expression<Func<TEntity, bool>> condition, CancellationToken token = default)
    {
        return await _dbContext.Set<TEntity>()
            .FirstOrDefaultAsync(condition, token);
    }
    public async Task<IEnumerable<TEntity?>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> condition)
    {
        return await _dbContext.Set<TEntity>().Where(condition).AsNoTracking().ToListAsync();
    }



    public async Task<TEntity?> GetById(Guid id)
    {
        return await _dbContext.FindAsync<TEntity>(id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbContext.Update<TEntity>(entity);
        await _dbContext.SaveChangesAsync();
    }
}
