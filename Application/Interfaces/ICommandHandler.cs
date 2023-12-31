﻿using MediatR;


namespace Application.Interfaces
{
    public interface ICommandHandler<TCommand, TResult> where TCommand : IRequest<TResult>
    {
        Task<TResult> Handle(TCommand command, CancellationToken token);
    }
}
