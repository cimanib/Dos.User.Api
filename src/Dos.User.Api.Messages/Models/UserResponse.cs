using System.Collections.Generic;

namespace Dos.User.Api.Messages.Models
{
    public class UserResponse
    {
        public IList<UserDto> Users { get; set; }
    }
}