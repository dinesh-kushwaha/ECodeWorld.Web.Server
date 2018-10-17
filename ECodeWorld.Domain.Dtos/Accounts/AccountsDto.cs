using ECodeWorld.Domain.Dtos.Core;
using ECodeWorld.Domain.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Dtos.Accounts
{
    public class AccountsDto : DtoBase
    {
        public AccountsDto()
        {
            RolesPermissions = new List<RolesPermissionsDto>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public IEnumerable<RolesPermissionsDto> RolesPermissions { get; set; }
    }
}
