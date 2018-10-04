using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class PostStatus
    {
        public PostStatus()
        {
            PostStatusMl = new HashSet<PostStatusMl>();
            PostTypesMl = new HashSet<PostTypesMl>();
            Posts = new HashSet<Posts>();
            TempPosts = new HashSet<TempPosts>();
        }

        public int Id { get; set; }
        public string Pstatus { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

        public ICollection<PostStatusMl> PostStatusMl { get; set; }
        public ICollection<PostTypesMl> PostTypesMl { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<TempPosts> TempPosts { get; set; }
    }
}
