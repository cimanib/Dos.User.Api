using MediatR;

namespace Dos.User.Api.Infrastructure.Mediator
{
    public abstract class Query<TResponse>
       : IRequest<TResponse> where TResponse : class
    {
    }
}
