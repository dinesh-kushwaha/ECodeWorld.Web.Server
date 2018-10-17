using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class UsersCertifications
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UsersId { get; set; }
        public int? CertificationsId { get; set; }
        public DateTime? QualificationDate { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public int? Order { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Certifications Certifications { get; set; }
        public Users Users { get; set; }
    }
}
