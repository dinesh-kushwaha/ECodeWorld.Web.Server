using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class ApproverTypesUsers
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int ApproverTypesId { get; set; }
        public int? PostCategoriesId { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ApproverTypes ApproverTypes { get; set; }
        public PostCategories PostCategories { get; set; }
        public Users Users { get; set; }
    }
}
