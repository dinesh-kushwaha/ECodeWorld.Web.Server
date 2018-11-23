using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Dtos.Accounts
{
    public class UsersGroupsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? UsersId { get; set; }
        public int? GroupsId { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public GroupsDto Groups { get; set; }
    }
}
