using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class PostsCategories
    {
        public PostsCategories()
        {
            ApproverTypesUsers = new HashSet<ApproverTypesUsers>();
            Posts = new HashSet<Posts>();
            PostsCategoriesMl = new HashSet<PostsCategoriesMl>();
            TempPosts = new HashSet<TempPosts>();
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ICollection<ApproverTypesUsers> ApproverTypesUsers { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<PostsCategoriesMl> PostsCategoriesMl { get; set; }
        public ICollection<TempPosts> TempPosts { get; set; }
    }
}
