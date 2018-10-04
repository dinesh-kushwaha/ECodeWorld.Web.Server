using ECodeWorld.Domain.CrossCutting.Specifications.Core;
using ECodeWorld.Domain.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Application.Specifications.User
{
    public class UserSpecification : CompositeSpecification<UserDto>
    {
        public override bool IsSatisfiedBy(UserDto candidate)
        {
            return true;
        }
    }
}
