using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Memberships
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int? UsersId { get; set; }
        public int? CompaniesId { get; set; }
        public int? RolesId { get; set; }
        public DateTime Date { get; set; }

        public Companies Companies { get; set; }
        public Roles Roles { get; set; }
        public Users Users { get; set; }
    }
}
