using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            Companies = new HashSet<Companies>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AccountPlanLevelsId { get; set; }
        public DateTime Date { get; set; }

        public AccountPlanLevels AccountPlanLevels { get; set; }
        public ICollection<Companies> Companies { get; set; }
    }
}
