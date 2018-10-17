using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Groups
    {
        public Groups()
        {
            GroupsPolicies = new HashSet<GroupsPolicies>();
            GroupsRoles = new HashSet<GroupsRoles>();
            UsersGroups = new HashSet<UsersGroups>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ICollection<GroupsPolicies> GroupsPolicies { get; set; }
        public ICollection<GroupsRoles> GroupsRoles { get; set; }
        public ICollection<UsersGroups> UsersGroups { get; set; }
    }
}
