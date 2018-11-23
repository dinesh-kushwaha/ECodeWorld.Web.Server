using ECodeWorld.Domain.Application.Services.Accounts;
using ECodeWorld.Domain.Application.Services.Authentication;
using ECodeWorld.Domain.Application.Services.User;
using ECodeWorld.Domain.CrossCutting.Adapters.Accounts;
using ECodeWorld.Domain.Dtos.Accounts;
using ECodeWorld.Domain.Dtos.Authentication;
using ECodeWorld.Domain.Dtos.Message;
using ECodeWorld.Domain.Dtos.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECodeWorld.Web.API.Controllers.Accounts
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    [EnableCors("CorsPolicy")]
    public class AccountsController : Controller
    {
        private readonly IAccountsService accountsService;
        private readonly IAuthenticationService authenticationService;
        private readonly IUserService userService;

        public AccountsController(IAuthenticationService authenticationService,
            IUserService userService, IAccountsService accountsService)
        {
            this.accountsService = accountsService;
            this.authenticationService = authenticationService;
            this.userService = userService;
        }

        [HttpGet("Permissions")]
        public async Task<AccountsDto> GetPermissions(int userId)
        {
            return await accountsService.GetAccounts(userId);
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
        [HttpPost("UpdateUserProfile")]
        public async Task<ResponseDto> UpdateUserProfile([FromBody]AccountsDto accountsDto)
        {
            return await this.userService.UpdateUserProfile(accountsDto);
        }

        [HttpPost("GetUserProfile/{userId}")]
        public async Task<AccountsDto> GetUserProfile(int userId)
        {
            return await accountsService.GetAccounts(userId);
        }
    }
}