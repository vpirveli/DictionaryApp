using Application.DTOs;
using Application.Interfaces;
using Application.Queries;
using Domain.Abstraction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    internal class GetWordHandler : MediatR.IRequestHandler<GetWordQuery, WordDTO>
    {
        private IGenericRepository<Word> _repository;

        public GetWordHandler(IGenericRepository<Word> repository)
        {
            _repository = repository;
        }

        public async Task<WordDTO> Handle(GetWordQuery query, CancellationToken token)
        {
            Word word = new Word();
            word = await _repository.GetById(query.WordId);

            List<string> definitions = word.Definition.Select(d => d.Description).ToList();

            WordDTO wordDTO = new WordDTO()
            {
                Term = word.Term,
                Definition = definitions
            };

            return wordDTO;
        }
    }
}
