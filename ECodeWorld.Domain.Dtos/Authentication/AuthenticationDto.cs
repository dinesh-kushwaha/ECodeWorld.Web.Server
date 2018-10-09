using ECodeWorld.Domain.Dtos.Message;

namespace ECodeWorld.Domain.Dtos.Authentication
{
    public class AuthenticationDto : ResponseDto
    {
        public string Name { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
