﻿using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class PostTypesMl
    {
        public int Id { get; set; }
        public int? PostTypesId { get; set; }
        public int? LanguageId { get; set; }
        public string Ptype { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Languages Language { get; set; }
        public PostStatus PostTypes { get; set; }
    }
}