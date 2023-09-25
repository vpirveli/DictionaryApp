using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRequestHandler<TRequest, TResult> where TRequest : IRequest<TResult>
    {
        Task<TResult> Handle(TRequest command, CancellationToken token);
    }
}
