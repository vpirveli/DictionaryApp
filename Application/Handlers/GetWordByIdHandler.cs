using Application.DTOs;
using Application.Interfaces;
using Application.Queries;
using Domain.Abstraction;
using Domain.Entities;

namespace Application.Handlers
{
    internal class GetWordByIdHandler : MediatR.IRequestHandler<GetWordByIdQuery, WordDTO>
    {
        private IGenericRepository<Word> _repositoryWord;
        private IGenericRepository<Definition> _repositoryDefinition;
        private IQueryServices _queryServices;

        public GetWordByIdHandler(IGenericRepository<Word> repositoryWord, IGenericRepository<Definition> repositoryDefinition, IQueryServices queryServices)
        {
            _repositoryWord = repositoryWord;
            _repositoryDefinition = repositoryDefinition;
            _queryServices = queryServices;
        }

        public async Task<WordDTO> Handle(GetWordByIdQuery query, CancellationToken token)
        {
            Word word = await _repositoryWord.GetById(query.Id);

            var foreignKeyName = _queryServices.GetCollumnNameAttribute(typeof(Definition), nameof(Definition.WordId));

            IEnumerable<Definition> definition = await _repositoryDefinition
                                                    .GetAllByForeignKeyAsync(word.Id, foreignKeyName);

            List<string> description = definition
                                            .Select(d => d.Description).ToList();

            WordDTO wordDTO = new WordDTO()
            {
                Term = word.Term,
                Description = description
            };

            return wordDTO;
        }
    }
}
