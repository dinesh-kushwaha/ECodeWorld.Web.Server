using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Comments
    {
        public Comments()
        {
            CommentsMl = new HashSet<CommentsMl>();
        }

        public int Id { get; set; }
        public int? Count { get; set; }
        public string AuthorIp { get; set; }
        public string Content { get; set; }
        public bool? Approved { get; set; }
        public int? LikeCounts { get; set; }
        public string AuthorEmail { get; set; }
        public int? AuthorsId { get; set; }
        public int? PostsId { get; set; }
        public DateTime Date { get; set; }

        public Users Authors { get; set; }
        public Posts Posts { get; set; }
        public ICollection<CommentsMl> CommentsMl { get; set; }
    }
}
