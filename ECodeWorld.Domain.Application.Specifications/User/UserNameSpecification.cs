using ECodeWorld.Domain.CrossCutting.Specifications.Core;
using ECodeWorld.Domain.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Application.Specifications.User
{
    public class UserNameSpecification : ISpecification<UserDto>
    {
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
            if (string.IsNullOrEmpty(candidate.Password))
            {
                candidate.AddRule("userDto", "UserName is empty.");
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
