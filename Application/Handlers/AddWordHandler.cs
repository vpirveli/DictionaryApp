using Application.Commands;
using Application.DTOs;
using MediatR;
using Domain.Abstraction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Application.Handlers
{
    public class AddWordHandler : IRequestHandler<AddWordCommand, Guid>
    {
        private IGenericEFRepository<Word> _repository;
        private IGenericEFRepository<Definition> _definitionRepository;

        public AddWordHandler(IGenericEFRepository<Word> repository, IGenericEFRepository<Definition> definitionRepository)
        {
            _repository = repository;
            _definitionRepository = definitionRepository;
        }

        public async Task<Guid> Handle(AddWordCommand request, CancellationToken token)
        {
            Word? word =  null;

            try
            {
                word = await _repository.GetByConditionAsync(e => e.Term == request.Term, token);//change
            }
            catch (Exception ex) { };


            if (word is null)
            {
                Word wordDb = new Word() { Term = request.Term };

                wordDb.Definition = new List<Definition> { new Definition() { Description = request.Description } };

                await _repository.AddAsync(wordDb);

                return wordDb.Id;
            }
            else
            {
                await _definitionRepository.AddAsync(new Definition() { Description = request.Description, WordId = word.Id });
            }

            return word.Id;
        }
    }
}
