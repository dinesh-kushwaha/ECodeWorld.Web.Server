using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECodeWorld.Domain.Application.Services.Authentication;
using ECodeWorld.Domain.Application.Services.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECodeWorld.Web.API.Controllers.Accounts
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    [EnableCors("CorsPolicy")]
    public class AccountsController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUserService userService;
        public AccountsController(IAuthenticationService authenticationService, IUserService userService)
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
        }

    }
}