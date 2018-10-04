using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class Logins
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public int? UsersId { get; set; }
        public DateTime Date { get; set; }

        public Users Users { get; set; }
    }
}
