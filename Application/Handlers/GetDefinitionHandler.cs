using MediatR;
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
    public class GetDefinitionHandler : IRequestHandler<GetDefinitionQuery, Definition>
    {
        private IGenericRepository<Definition> _repository;

        public GetDefinitionHandler(IGenericRepository<Definition> repository)
        {
            _repository = repository;
        }

        public async Task<Definition> Handle(GetDefinitionQuery request, CancellationToken token)
        {
            return await _repository.GetByDescription(request.Definition);
        }
    }
}
