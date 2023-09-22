using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
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

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Update<TEntity>(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
