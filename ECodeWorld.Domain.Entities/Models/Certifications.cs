using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Certifications
    {
        public Certifications()
        {
            UserCertifications = new HashSet<UserCertifications>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public ICollection<UserCertifications> UserCertifications { get; set; }
    }
}
