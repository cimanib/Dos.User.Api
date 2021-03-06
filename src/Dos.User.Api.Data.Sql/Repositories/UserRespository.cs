using Dos.User.Api.Common;
using Dos.User.Api.Data.Queries;
using Dos.User.Api.Data.Specifications;
using Dos.User.Api.Domain.AggregateModels;
using Dos.User.Api.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dos.User.Api.Data.Sql.Repositories
{
    public class UserQueryRespository : IUserRespository
    {
        private readonly UserDbContext _context;
        public UserQueryRespository(UserDbContext userDbContext)
        {
            _context = Guard.IsNotNull(userDbContext, nameof(userDbContext));
            _context.ChangeTracker.AutoDetectChangesEnabled = true;

        }
        public Task<IEnumerable<UserEntity>> FilterUsers(string name, string surname, CancellationToken cancellationToken = default)
        {
            return FilterAsync(new UserSpecification(name, surname), cancellationToken);
        }
        private async Task<IEnumerable<UserEntity>> FilterAsync(ISpecification<UserEntity> specification, CancellationToken cancellationToken = default)
        {
            
                var queryableResultWithIncludes = specification.Includes
                    .Aggregate(_context.Set<UserEntity>().AsTracking<UserEntity>(),
                 (current, include) => current.Include(include));

                var secondaryResult = specification.IncludeStrings
                    .Aggregate(queryableResultWithIncludes,
                        (current, include) => current.Include(include));

                var entity = await secondaryResult
                                .Where(specification.Criteria)
                    .ToListAsync(cancellationToken);

                return entity;
            
        }

        
    }
}
