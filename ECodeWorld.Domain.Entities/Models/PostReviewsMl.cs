﻿using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class PostReviewsMl
    {
        public int Id { get; set; }
        public int PostReviewsId { get; set; }
        public int? LanguageId { get; set; }
        public string Comments { get; set; }
        public string Messages { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

        public Languages Language { get; set; }
        public PostReviews PostReviews { get; set; }
    }
}
