using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class PostTypes
    {
        public PostTypes()
        {
            Posts = new HashSet<Posts>();
            TempPosts = new HashSet<TempPosts>();
        }

        public int Id { get; set; }
        public string Ptype { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ICollection<Posts> Posts { get; set; }
        public ICollection<TempPosts> TempPosts { get; set; }
    }
}
