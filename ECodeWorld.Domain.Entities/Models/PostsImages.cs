using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class PostsImages
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Posts Post { get; set; }
    }
}
