using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class ApproverTypes
    {
        public ApproverTypes()
        {
            ApproverTypesUsers = new HashSet<ApproverTypesUsers>();
            ApproverTypessMl = new HashSet<ApproverTypessMl>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ICollection<ApproverTypesUsers> ApproverTypesUsers { get; set; }
        public ICollection<ApproverTypessMl> ApproverTypessMl { get; set; }
    }
}
