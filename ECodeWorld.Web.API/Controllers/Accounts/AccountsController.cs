using ECodeWorld.Domain.Application.Services.Accounts;
using ECodeWorld.Domain.CrossCutting.Adapters.Accounts;
using ECodeWorld.Domain.Dtos.Accounts;
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
        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        [HttpGet("Permissions")]
        public async Task<AccountsDto> GetPermissions(string userName)
        {
            return await accountsService.GetAccounts(userName);
        }
    }
}