using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class UsersPolicies
    {
        public int Id { get; set; }
        public int? UsersId { get; set; }
        public int? PoliciesId { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Policies Policies { get; set; }
        public Users Users { get; set; }
    }
}
