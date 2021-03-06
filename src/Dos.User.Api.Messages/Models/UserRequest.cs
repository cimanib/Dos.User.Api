using Dos.User.Api.Messages.Queries;

namespace Dos.User.Api.Messages.Models
{
    public sealed class UserRequest : BaseQuery<UserResponse>
    {

        public UserRequest(string name ,string surname)
        {
            Name = name;
            Surname = surname;

        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
    }
}