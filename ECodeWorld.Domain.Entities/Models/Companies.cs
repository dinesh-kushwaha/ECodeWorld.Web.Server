using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Companies
    {
        public Companies()
        {
            Memberships = new HashSet<Memberships>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AccessLevelsId { get; set; }
        public int? AccountsId { get; set; }
        public DateTime Date { get; set; }

        public AccessLevels AccessLevels { get; set; }
        public Accounts Accounts { get; set; }
        public ICollection<Memberships> Memberships { get; set; }
    }
}
