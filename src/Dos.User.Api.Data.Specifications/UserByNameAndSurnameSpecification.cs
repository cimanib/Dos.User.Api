using Dos.User.Api.Domain.AggregateModels;

namespace Dos.User.Api.Data.Specifications
{
    public class UserByNameAndSurnameSpecification : BaseSpecification<UserEntity>
    {
        public UserByNameAndSurnameSpecification(string name, string surname)
        : base(o => o.First_Name.Equals(name, System.StringComparison.OrdinalIgnoreCase)
        && o.Last_Name.Equals(surname, System.StringComparison.OrdinalIgnoreCase))
        {
        }

    }
}