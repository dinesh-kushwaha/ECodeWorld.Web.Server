using ECodeWorld.Domain.Entities.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ECodeWorld.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/ECWTeamMembers")]
    [EnableCors("CorsPolicy")]
    public class ECWTeamMembersController : Controller
    {

        // GET: api/ECWTeamMembers
        [HttpGet]
        public IEnumerable<UserProfiles> Get()
        {
            using (var db = new ECodeWorldContext())
            {
                return db.UserProfiles.ToList();
            }
        }

        // GET: api/ECWTeamMembers/5
        [HttpGet("{id}", Name = "Get")]
        public object Get(int id)
        {
            using (var db = new ECodeWorldContext())
            {
                return db.UserProfiles.Where(x => x.Id == id).FirstOrDefault();
            }
        }
        
        // POST: api/ECWTeamMembers
        [HttpPost]
        public void Post([FromBody]object userProfile)
        {
            //using (var db = new ECodeWorldContext())
            //{
            //    var userProfileInDB = db.UserProfiles.Where(x => x.Id == id).FirstOrDefault();
            //    return db.UserProfiles.Where(x => x.Id == id).FirstOrDefault();
            //}
        }
        
        // PUT: api/ECWTeamMembers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]object userProfile)
        {
            using (var db = new ECodeWorldContext())
            {
                var userProfileInDB = db.UserProfiles.Where(x => x.Id == id).FirstOrDefault();
                if (userProfileInDB != null)
                {
                    //userProfileInDB.Description = userProfile.Description;
                    //userProfileInDB.AboutMe = userProfile.AboutMe;

                }
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
