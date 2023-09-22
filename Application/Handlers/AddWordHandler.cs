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
    public class AddWordHandler : IRequestHandler<AddWordCommand, int>
    {
        private IGenericEFRepository<Word> _repository;

        public AddWordHandler(IGenericEFRepository<Word> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AddWordCommand request, CancellationToken token)
        {
            Word word = new Word() { Term = request.Term , Date = DateTime.Now};

            await _repository.AddAsync(word);

            return Convert.ToInt32(word.Id);
        }
    }
}
