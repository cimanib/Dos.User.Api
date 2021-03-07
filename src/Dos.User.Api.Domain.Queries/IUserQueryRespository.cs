using Dos.User.Api.Domain.AggregateModels;
using Dos.User.Api.Domain.Seedwork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dos.User.Api.Data.Queries
{
    public interface IUserRespository : IQueryRepository<UserEntity>
    {
       Task<IEnumerable<UserEntity>> GetAllUsers();
       Task<IEnumerable<UserEntity>> FilterUsers(string name, string surname, CancellationToken cancellationToken = default);
       
    }
}
