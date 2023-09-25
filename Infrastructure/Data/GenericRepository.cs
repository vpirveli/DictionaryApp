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


        public async Task<TEntity> GetById(Guid id)
        {
            var task = await _connection.QuerySingleOrDefaultAsync<TEntity>("SELECT * FROM " + typeof(TEntity).Name + " WHERE Id = @Id", new { Id = id });

            if (task == null)
            {
                // Handle the case where no entity with the given id was found.
                // You can return null or throw an exception, depending on your requirements.
                // For example, you can throw a custom NotFoundException:
                throw new ArgumentOutOfRangeException($"Entity with Id {id} not found.");
            }

            return task;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _connection.QueryAsync<TEntity>("SELECT * FROM " + typeof(TEntity).Name);
        }

        public async Task<TEntity> GetByDescription(string description)
        {
            return await _connection.QuerySingleOrDefaultAsync<TEntity>("SELECT * FROM " + typeof(TEntity).Name + " WHERE Description = @description", new { description = description });
        }
    }
}
