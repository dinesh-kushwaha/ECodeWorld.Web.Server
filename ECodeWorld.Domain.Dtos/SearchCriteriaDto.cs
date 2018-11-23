using ECodeWorld.Domain.Dtos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Dtos
{
    public class SearchCriteriaDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;
        public bool IsOrderByDescending { get; set; } = true;
        public int UserId { get; set; }
        public IDto Criteria { get; set; }
    }
}
