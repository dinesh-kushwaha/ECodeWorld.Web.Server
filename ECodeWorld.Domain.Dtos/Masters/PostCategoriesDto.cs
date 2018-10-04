using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Dtos.Masters
{
    public partial class PostCategoriesDto : IMasterDto
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

    }
}
