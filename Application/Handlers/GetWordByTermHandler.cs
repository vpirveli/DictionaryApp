using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Application.Queries;
using Domain.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    internal class GetWordByTermHandler : MediatR.IRequestHandler<GetWordByTermQuery, WordDTO>
    {
        private readonly IGenericRepository<Word> _repositoryWord;
        private readonly IGenericRepository<Definition> _repositoryDefinition;
        private readonly IQueryServices _queryServices;

        public GetWordByTermHandler(IGenericRepository<Word> repositoryWord, IGenericRepository<Definition> repositoryDefinition, IQueryServices queryServices)
        {
            _repositoryWord = repositoryWord;
            _repositoryDefinition = repositoryDefinition;
            _queryServices = queryServices;
        }

        public async Task<WordDTO> Handle(GetWordByTermQuery query, CancellationToken cancellationToken)
        {
            Word word = await _repositoryWord.GetByPropertyValue(query.Term);
            string? foreignKeyName = _queryServices.GetCollumnNameAttribute(typeof(Definition), nameof(Definition.WordId));
            
            IEnumerable<Definition> definition = await _repositoryDefinition.GetAllByForeignKeyAsync(word.Id, foreignKeyName);

            List<string> description = definition.Select(d => d.Description).ToList();

            WordDTO wordDTO = new WordDTO()
            {
                Term = word.Term,
                Description = description
            };

            return wordDTO;
        }
    }
}
