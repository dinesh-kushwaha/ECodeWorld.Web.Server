using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class ComplexityLevels
    {
        public ComplexityLevels()
        {
            ComplexityLevelsMl = new HashSet<ComplexityLevelsMl>();
            Posts = new HashSet<Posts>();
            TempPosts = new HashSet<TempPosts>();
        }

        public int Id { get; set; }
        public string Complexity { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

        public ICollection<ComplexityLevelsMl> ComplexityLevelsMl { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<TempPosts> TempPosts { get; set; }
    }
}
