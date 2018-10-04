using ECodeWorld.Domain.CrossCutting.Specifications.Core;
using ECodeWorld.Domain.Dtos.Users;

namespace ECodeWorld.Domain.Application.Specifications.User
{
    public class PasswordSpecification : ISpecification<UserDto>
    {
        public ISpecification<UserDto> And(ISpecification<UserDto> other)
        {
            throw new System.NotImplementedException();
        }

        public ISpecification<UserDto> AndNot(ISpecification<UserDto> other)
        {
            throw new System.NotImplementedException();
        }

        public bool IsSatisfiedBy(UserDto candidate)
        {
            if (string.IsNullOrEmpty(candidate.Password))
            {
                candidate.AddRule("userDto", "Password is empty.");
                candidate.HasError = true;
                return false;
            }
            else {
                return true;
            }
        }

        public ISpecification<UserDto> Not()
        {
            throw new System.NotImplementedException();
        }

        public ISpecification<UserDto> Or(ISpecification<UserDto> other)
        {
            throw new System.NotImplementedException();
        }

        public ISpecification<UserDto> OrNot(ISpecification<UserDto> other)
        {
            throw new System.NotImplementedException();
        }
    }
}
