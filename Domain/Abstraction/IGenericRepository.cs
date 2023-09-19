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
        Task<int> AddWordAsync(Word word);
        Task<Word> GetWordByIdAsync(int id);
        Task<Word> GetWordByDefinitionAsync(Definition definition);
        Task<List<BinaryWriter>> GetWordsAsync();
        Task<IEnumerable<T>> CustomQuery<T>();
    }
}
