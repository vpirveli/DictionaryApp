using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using Domain.Abstraction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class AddWordHandler : MediatR.IRequestHandler<AddWordCommand, Guid>
    {
        private IGenericEFRepository<Word> _repository;

        public AddWordHandler(IGenericEFRepository<Word> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(AddWordCommand request, CancellationToken token)
        {
            Word word = new Word() { Term = request.Term};

            word.Definition = new List<Definition> { new Definition() { Description = request.Description } };

            await _repository.AddAsync(word);

            return word.Id;
        }
    }
}
