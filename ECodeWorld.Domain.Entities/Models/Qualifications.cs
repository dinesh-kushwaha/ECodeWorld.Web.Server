using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Qualifications
    {
        public Qualifications()
        {
            UserQualifications = new HashSet<UserQualifications>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public ICollection<UserQualifications> UserQualifications { get; set; }
    }
}
