using System;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Entities.Models
{
    public partial class UserProfiles
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string AboutMe { get; set; }
        public string Banner { get; set; }
        public string Logo { get; set; }
        public string Icon { get; set; }
        public string Avtar { get; set; }
        public int? UsersId { get; set; }
        public DateTime Date { get; set; }

        public Users Users { get; set; }
    }
}
