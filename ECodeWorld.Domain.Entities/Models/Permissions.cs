using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Permissions
    {
        public Permissions()
        {
            Policies = new HashSet<Policies>();
            RolesPermissions = new HashSet<RolesPermissions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ActionCode { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ICollection<Policies> Policies { get; set; }
        public ICollection<RolesPermissions> RolesPermissions { get; set; }
    }
}
