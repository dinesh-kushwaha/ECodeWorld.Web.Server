using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Dtos.Accounts
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public DateTime Date { get; set; }
    }
}
