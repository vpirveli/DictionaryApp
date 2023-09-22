using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IRequest<TResult>
    {
        Task<TResult> Handle(TQuery query, CancellationToken token);
    }
}
