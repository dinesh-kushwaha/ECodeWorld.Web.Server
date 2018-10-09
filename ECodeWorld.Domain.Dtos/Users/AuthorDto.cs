using ECodeWorld.Domain.Dtos.Core;

namespace ECodeWorld.Domain.Dtos.Users
{
    public class AuthorDto :IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
       
    }
}
