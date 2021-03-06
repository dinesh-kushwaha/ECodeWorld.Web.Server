﻿using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class PostStatusMl
    {
        public int Id { get; set; }
        public int? PostStatusId { get; set; }
        public int? LanguageId { get; set; }
        public string Pstatus { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public Languages Language { get; set; }
        public PostStatus PostStatus { get; set; }
    }
}
