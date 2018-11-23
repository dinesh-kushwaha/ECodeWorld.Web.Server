using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Dtos.Accounts
{
    public class UsersQualificationsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UsersId { get; set; }
        public int? QualificationsId { get; set; }
        public int? UniversitiesId { get; set; }
        public DateTime? QualificationDate { get; set; }
        public int? Order { get; set; }
        public DateTime Date { get; set; }
        public QualificationsDto Qualifications { get; set; }
        public UniversitiesDto Universities { get; set; }
    }
}
