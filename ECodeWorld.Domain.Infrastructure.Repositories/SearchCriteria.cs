using ECodeWorld.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Infrastructure.Repositories
{
    public class SearchCriteria
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;
        public bool IsOrderByDescending { get; set; } = true;
        public int UserId { get; set; }
        public Object Criteria { get; set; }
    }
}
