using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class PostsStatusMl
    {
        public int Id { get; set; }
        public int? PostsStatusId { get; set; }
        public int? LanguageId { get; set; }
        public string Pstatus { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Languages Language { get; set; }
        public PostsStatus PostsStatus { get; set; }
    }
}
