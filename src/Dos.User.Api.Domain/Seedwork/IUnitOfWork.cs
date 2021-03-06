using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dos.User.Api.Domain.Seedwork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}