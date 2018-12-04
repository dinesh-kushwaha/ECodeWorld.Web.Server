﻿using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class TempPostsMl
    {
        public int Id { get; set; }
        public int? TempPostsId { get; set; }
        public int? LanguageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Contents { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Languages Language { get; set; }
        public TempPosts TempPosts { get; set; }
    }
}
