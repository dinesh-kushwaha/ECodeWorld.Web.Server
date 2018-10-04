using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Memberships = new HashSet<Memberships>();
        }

        public int Id { get; set; }
        public string Role { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Memberships> Memberships { get; set; }
    }
}
