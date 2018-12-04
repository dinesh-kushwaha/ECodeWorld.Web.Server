using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Dtos.Posts
{
    public class PostsReviewersMlDto
    {
        public int Id { get; set; }
        public int PostReviewsId { get; set; }
        public int? LanguageId { get; set; }
        public string Comments { get; set; }
        public string Messages { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public PostsReviewersDto PostReviews { get; set; }
    }
}
