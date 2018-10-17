using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class GroupsPolicies
    {
        public int Id { get; set; }
        public int? GroupsId { get; set; }
        public int? PoliciesId { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Groups Groups { get; set; }
        public Policies Policies { get; set; }
    }
}
