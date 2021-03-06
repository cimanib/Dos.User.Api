using Dos.User.Api.Infrastructure.Mediator;

namespace Dos.User.Api.Messages.Queries
{
    public abstract class BaseQuery<TResponse> : Query<TResponse> where TResponse : class
    { }
}
