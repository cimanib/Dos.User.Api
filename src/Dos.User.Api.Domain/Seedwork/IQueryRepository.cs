namespace Dos.User.Api.Domain.Seedwork
{
    public interface IQueryRepository<T>
       where T : IAggregateRoot
    {
        //Task<IEnumerable<T>> FilterAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
    }
}
