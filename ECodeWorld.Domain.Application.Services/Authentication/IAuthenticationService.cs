using ECodeWorld.Domain.Application.Services.Core;
using ECodeWorld.Domain.Dtos.Authentication;
using ECodeWorld.Domain.Dtos.Message;
using ECodeWorld.Domain.Dtos.Users;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Authentication
{
    public interface IAuthenticationService : IService
    {
        Task<AuthenticationDto> VerifyUser(UserDto userDto);
        Task<ResponseDto> CreateUserLogin(UserDto userDto);

    }
}
