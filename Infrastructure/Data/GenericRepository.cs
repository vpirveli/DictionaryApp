using Dapper;
using Domain.Abstraction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        IDbConnection _connection;

        public GenericRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public Task<IEnumerable<TEntity>> CustomQueryAsync<TEntity>()
        {
            throw new NotImplementedException();
        }


        public async Task<TEntity> GetById(int id)
        {
            return await _connection.QuerySingleOrDefaultAsync<TEntity>("SELECT * FROM " + typeof(TEntity).Name + " WHERE Id = @Id", new { Id = id });
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _connection.QueryAsync<TEntity>("SELECT * FROM " + typeof(TEntity).Name);
        }
    }
}
