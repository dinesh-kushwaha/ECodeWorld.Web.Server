using ECodeWorld.Domain.Dtos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Dtos.Masters
{
    public class ApproverTypesDto : DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
    }
}
