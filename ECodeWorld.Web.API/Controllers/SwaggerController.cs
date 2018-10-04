using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECodeWorld.Web.API.Controllers
{
    [Route("[controller]")]
    public class SwaggerController : Controller
    {
        // GET Swagger
        [HttpGet]
        public void help()
        {
            
        }
    }
}