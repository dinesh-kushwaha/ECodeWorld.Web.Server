using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class PostsApprovalsMl
    {
        public int Id { get; set; }
        public int PostsApprovalsId { get; set; }
        public int? LanguageId { get; set; }
        public string Comments { get; set; }
        public string Messages { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Languages Language { get; set; }
        public PostsApprovals PostsApprovals { get; set; }
    }
}
