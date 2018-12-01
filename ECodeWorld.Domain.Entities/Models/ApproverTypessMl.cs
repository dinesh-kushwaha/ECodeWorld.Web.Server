using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class ApproverTypessMl
    {
        public int Id { get; set; }
        public int? ApproverTypesId { get; set; }
        public int? LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ApproverTypes ApproverTypes { get; set; }
        public Languages Language { get; set; }
    }
}
