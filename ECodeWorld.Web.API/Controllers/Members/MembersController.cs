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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Web.API.Controllers.Members
{
    [Produces("application/json")]
    [Route("api/Members")]
    [EnableCors("CorsPolicy")]
    public class MembersController
    {
        private readonly IAccountsService accountsService;
        private readonly IAuthenticationService authenticationService;
        private readonly IUserService userService;

        public MembersController(IAuthenticationService authenticationService,
            IUserService userService, IAccountsService accountsService)
        {
            this.accountsService = accountsService;
            this.authenticationService = authenticationService;
            this.userService = userService;
        }

        [HttpGet("GetMember/{memberId}")]
        public async Task<AccountsDto> GetMember(int memberId)
        {
            return await accountsService.GetAccounts(memberId);
        }

        [HttpGet("GetMembers/{isWebUser}")]
        public async Task<IEnumerable<UsersProfilesDto>> GetMembers(bool isWebUser)
        {
            return await accountsService.GetMembers(isWebUser);
        }

    }
}
