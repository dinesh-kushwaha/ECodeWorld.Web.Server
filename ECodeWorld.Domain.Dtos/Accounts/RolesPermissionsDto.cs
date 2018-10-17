using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Dtos.Accounts
{
    public class RolesPermissionsDto
    {
        public EcwresourcesDto Ecwresources { get; set; }
        public PermissionsDto Permissions { get; set; }
    }
}
