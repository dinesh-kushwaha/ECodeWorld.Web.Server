using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class CommentsMl
    {
        public int Id { get; set; }
        public int CommentsId { get; set; }
        public int? LanguageId { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

        public Comments Comments { get; set; }
        public Languages Language { get; set; }
    }
}
