using Dos.User.Api.Common;
using Dos.User.Api.Data.Queries;
using Dos.User.Api.Infrastructure.Mediator;
using Dos.User.Api.Messages.Models;
using Dos.User.Api.Messages.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dos.User.Api.Handlers
{
    public sealed class GetUsersQueryHandler : QueryHandler<GetUsersQuery, UserResponse>
    {
        private readonly IUserRespository _userRespository;

        public GetUsersQueryHandler(IUserRespository userRespository)
        {
            _userRespository = Guard.IsNotNull(userRespository, nameof(userRespository));
        }

        public override async Task<UserResponse> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            var response = await _userRespository.FilterUsers(query.Name, query.Surname);

            if (response == null || !response.Any())

                return new UserResponse();

            return new UserResponse
            {
                Users = response.Select(x => new UserDto
                {
                    FirstName = x.First_Name,
                    LastName = x.Last_Name,
                    Address = x.Address,
                    City = x.City,
                    Country = x.Country,
                    DateOfBirth = x.Date_Of_Birth,
                    EmailAddress = x.Email_Address,
                    ZipCode = x.Zip_Code
                }).ToList()
            };
        }
    }
}