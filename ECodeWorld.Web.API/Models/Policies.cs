using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class Policies
    {
        public Policies()
        {
            GroupsPolicies = new HashSet<GroupsPolicies>();
            UsersPolicies = new HashSet<UsersPolicies>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? EcwresourcesId { get; set; }
        public int? PermissionsId { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Ecwresources Ecwresources { get; set; }
        public Permissions Permissions { get; set; }
        public ICollection<GroupsPolicies> GroupsPolicies { get; set; }
        public ICollection<UsersPolicies> UsersPolicies { get; set; }
    }
}
