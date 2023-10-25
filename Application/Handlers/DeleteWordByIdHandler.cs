using Application.Commands;
using MediatR;
using Domain.Abstraction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class DeleteWordByIdHandler : IRequestHandler<DeleteWordByIdCommand, Guid>
    {
        private IGenericEFRepository<Word> _wordRepository;
        private IGenericEFRepository<Definition> _definitionRepository;

        public DeleteWordByIdHandler(IGenericEFRepository<Word> repository, IGenericEFRepository<Definition> definitionRepository)
        {
            _wordRepository = repository;
            _definitionRepository = definitionRepository;
        }

        public async Task<Guid> Handle(DeleteWordByIdCommand command, CancellationToken token)
        {
            var word = await _wordRepository.GetById(command.Id);
            if (word == null)
            {
                throw new NullReferenceException("Word you're looking for is not in the Database");
            }
            IEnumerable<Definition?> definitions = await _definitionRepository.GetAllByConditionAsync(d => d.WordId == command.Id);
            if (definitions != null)
            {
                await _definitionRepository.DeleteRangeAsync(definitions);
            }
            await _wordRepository.DeleteAsync(word);
            return word.Id;

        }
    }
}
