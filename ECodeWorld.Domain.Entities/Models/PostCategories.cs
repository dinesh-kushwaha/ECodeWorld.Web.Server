using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class PostCategories
    {
        public PostCategories()
        {
            PostCategoriesMl = new HashSet<PostCategoriesMl>();
            Posts = new HashSet<Posts>();
            TempPosts = new HashSet<TempPosts>();
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

        public ICollection<PostCategoriesMl> PostCategoriesMl { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<TempPosts> TempPosts { get; set; }
    }
}
