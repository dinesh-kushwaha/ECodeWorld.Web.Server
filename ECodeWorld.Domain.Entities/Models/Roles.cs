using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Roles
    {
        public Roles()
        {
            GroupsRoles = new HashSet<GroupsRoles>();
            RolesPermissions = new HashSet<RolesPermissions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ICollection<GroupsRoles> GroupsRoles { get; set; }
        public ICollection<RolesPermissions> RolesPermissions { get; set; }
    }
}
