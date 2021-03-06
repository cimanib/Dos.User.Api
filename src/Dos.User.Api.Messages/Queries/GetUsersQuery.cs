using Dos.User.Api.Messages.Models;

namespace Dos.User.Api.Messages.Queries
{
    public sealed class GetUsersQuery : BaseQuery<UserResponse>
    {
 
        public GetUsersQuery(string name, string surname)
        {
            Name = name;
            Surname = surname;

        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
    }
}