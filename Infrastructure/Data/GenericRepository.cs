using Domain.Abstraction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public Task<int> AddWordAsync(Word word)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> CustomQuery<T>()
        {
            throw new NotImplementedException();
        }

        public Task<Word> GetWordByDefinitionAsync(Definition definition)
        {
            throw new NotImplementedException();
        }

        public Task<Word> GetWordByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BinaryWriter>> GetWordsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
