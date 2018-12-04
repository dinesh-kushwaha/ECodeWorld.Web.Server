using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class Certifications
    {
        public Certifications()
        {
            UsersCertifications = new HashSet<UsersCertifications>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public ICollection<UsersCertifications> UsersCertifications { get; set; }
    }
}
