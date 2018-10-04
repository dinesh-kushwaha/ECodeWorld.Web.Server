using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class AccessLevels
    {
        public AccessLevels()
        {
            Companies = new HashSet<Companies>();
        }

        public int Id { get; set; }
        public string AccessLevel { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Companies> Companies { get; set; }
    }
}
