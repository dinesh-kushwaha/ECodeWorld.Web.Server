using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class PostCategoriesMl
    {
        public int Id { get; set; }
        public int? PostCategoriesId { get; set; }
        public int? LanguageId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Languages Language { get; set; }
        public PostCategories PostCategories { get; set; }
    }
}
