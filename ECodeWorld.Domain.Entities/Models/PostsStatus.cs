using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class PostsStatus
    {
        public PostsStatus()
        {
            Posts = new HashSet<Posts>();
            PostsStatusMl = new HashSet<PostsStatusMl>();
            PostsTypesMl = new HashSet<PostsTypesMl>();
            TempPosts = new HashSet<TempPosts>();
        }

        public int Id { get; set; }
        public string Pstatus { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ICollection<Posts> Posts { get; set; }
        public ICollection<PostsStatusMl> PostsStatusMl { get; set; }
        public ICollection<PostsTypesMl> PostsTypesMl { get; set; }
        public ICollection<TempPosts> TempPosts { get; set; }
    }
}
