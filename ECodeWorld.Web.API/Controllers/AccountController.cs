using ECodeWorld.Domain.Application.Services.Authentication;
using ECodeWorld.Domain.Application.Services.User;
using ECodeWorld.Domain.Dtos.Authentication;
using ECodeWorld.Domain.Dtos.Core;
using ECodeWorld.Domain.Dtos.Message;
using ECodeWorld.Domain.Dtos.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECodeWorld.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    [EnableCors("CorsPolicy")]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUserService userService;
        public AccountController(IAuthenticationService authenticationService, IUserService userService)
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
        }


        [HttpPost("SignIn")]
        public async Task<AuthenticationDto> SignIn([FromBody]UserDto userDto)
        {
            return await this.authenticationService.VerifyUser(userDto);
        }

        [HttpPost("Register")]
        public async Task<UserDto> Register([FromBody]UserDto userDto)
        {
            return await this.userService.CreateUser(userDto);
        }
        //[HttpPost("UpdateUserProfile")]
        //public async Task<ResponseDto> UpdateUserProfile([FromBody]UserProfileDto userProfileDto)
        //{
        //    return await this.userService.UpdateUserProfile(userProfileDto);
        //}

    }
}
