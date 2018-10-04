using ECodeWorld.Domain.CrossCutting.Specifications.Core;
using ECodeWorld.Domain.Dtos.Users;
using ECodeWorld.Domain.Infrastructure.Repositories.User;

namespace ECodeWorld.Domain.Application.Specifications.User
{
    public class UniqueUserSpecification : ISpecification<UserDto>
    {
        private readonly IUserRepository userRepository;
        public UniqueUserSpecification(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public ISpecification<UserDto> And(ISpecification<UserDto> other)
        {
            return this;
        }

        public ISpecification<UserDto> AndNot(ISpecification<UserDto> other)
        {
            return this;
        }

        public bool IsSatisfiedBy(UserDto candidate)
        {
            var user =this.userRepository.GetUserByUserName(candidate.UserName);
            if (user.Result != null)
            {
                candidate.AddRule("userDto", "Duplicate user.");
                candidate.HasError = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        public ISpecification<UserDto> Not()
        {
            return this;
        }

        public ISpecification<UserDto> Or(ISpecification<UserDto> other)
        {
            return this;
        }

        public ISpecification<UserDto> OrNot(ISpecification<UserDto> other)
        {
            return this;
        }
    }
}
