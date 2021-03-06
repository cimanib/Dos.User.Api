using Dos.User.Api.Domain.AggregateModels;

namespace Dos.User.Api.Data.Specifications
{
    public class UserSpecification : BaseSpecification<UserEntity>
    {
        public UserSpecification(string name, string surname)
        : base(o => o.First_Name.Equals(name, System.StringComparison.OrdinalIgnoreCase)
        && o.Last_Name.Equals(surname, System.StringComparison.OrdinalIgnoreCase))
        {
        }

        public override bool IsSatisfiedBy(UserEntity candidate)
        {
            if (!string.IsNullOrEmpty(candidate.First_Name) || !string.IsNullOrEmpty(candidate.Last_Name))
                return false;
            return true;
        }
    }
}