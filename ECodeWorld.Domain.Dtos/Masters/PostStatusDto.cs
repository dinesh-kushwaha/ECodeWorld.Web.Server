﻿using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Dtos.Masters
{
    public partial class PostStatusDto : IMasterDto
    {
        public string Pstatus { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
    }
}
