using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class GroupsRoles
    {
        public int Id { get; set; }
        public int? GroupsId { get; set; }
        public int? RolesId { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Groups Groups { get; set; }
        public Roles Roles { get; set; }
    }
}
