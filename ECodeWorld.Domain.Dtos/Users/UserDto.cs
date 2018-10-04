using ECodeWorld.Domain.Dtos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Dtos.Users
{
    public class UserDto : DtoBase, IUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
