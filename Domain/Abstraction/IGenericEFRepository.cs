using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    public interface IGenericEFRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetByConditionAsync(Expression<Func<TEntity, bool>> condition, CancellationToken token = default);
        Task<IEnumerable<TEntity?>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> condition);
        Task<TEntity?> GetById(Guid id);
    }
}
