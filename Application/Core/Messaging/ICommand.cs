using MediatR;

namespace Application.Core.Messaging;

public interface ICommand : IRequest
{

}

public interface ICommand<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{

}
