using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    public interface IGenericEFRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
