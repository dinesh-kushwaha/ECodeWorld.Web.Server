using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class LikesCounters
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string LikeIp { get; set; }
        public int? PostsId { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Posts Posts { get; set; }
    }
}
