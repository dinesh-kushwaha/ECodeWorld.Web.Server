using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Dtos.Masters
{
    public class PostTypesDto : IMasterDto
    {
        public string Ptype { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
    }
}
