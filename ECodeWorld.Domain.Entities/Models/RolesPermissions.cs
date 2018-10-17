using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class RolesPermissions
    {
        public int Id { get; set; }
        public int? RolesId { get; set; }
        public int? EcwresourcesId { get; set; }
        public int? PermissionsId { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Ecwresources Ecwresources { get; set; }
        public Permissions Permissions { get; set; }
        public Roles Roles { get; set; }
    }
}
