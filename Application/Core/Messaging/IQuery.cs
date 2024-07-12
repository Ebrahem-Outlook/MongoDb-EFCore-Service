using MediatR;

namespace Application.Core.Messaging;

public interface IQuery : IRequest
{

}


public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{

}
