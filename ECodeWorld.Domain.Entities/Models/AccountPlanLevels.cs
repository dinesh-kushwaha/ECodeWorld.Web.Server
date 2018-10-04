using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class AccountPlanLevels
    {
        public AccountPlanLevels()
        {
            Accounts = new HashSet<Accounts>();
        }

        public int Id { get; set; }
        public string AccountPlanLevel { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Accounts> Accounts { get; set; }
    }
}
