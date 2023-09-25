using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<T>> CustomQueryAsync<T>();
        Task<TEntity> GetByDescription(string description);
    }
}
