using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class PostsCategoriesMl
    {
        public int Id { get; set; }
        public int? PostsCategoriesId { get; set; }
        public int? LanguageId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Languages Language { get; set; }
        public PostsCategories PostsCategories { get; set; }
    }
}
