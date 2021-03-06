using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dos.User.Api.Infrastructure.Mediator
{
    public abstract class QueryHandler<TRequest, TResponse>
        : IRequestHandler<TRequest, TResponse>
           where TRequest : Query<TResponse>
           where TResponse : class

    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}