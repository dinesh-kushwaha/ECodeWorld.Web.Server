using System;
using System.Collections.Generic;

namespace ECodeWorld.Web.API.Models
{
    public partial class UsersQualifications
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UsersId { get; set; }
        public int? QualificationsId { get; set; }
        public int? UniversitiesId { get; set; }
        public DateTime? QualificationDate { get; set; }
        public int? Order { get; set; }
        public DateTime Date { get; set; }
        public byte[] Timestamp { get; set; }

        public Qualifications Qualifications { get; set; }
        public Universities Universities { get; set; }
        public Users Users { get; set; }
    }
}
