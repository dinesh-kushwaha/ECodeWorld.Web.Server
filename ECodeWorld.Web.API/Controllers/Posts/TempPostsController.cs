using ECodeWorld.Domain.Application.Services.Posts;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Message;
using ECodeWorld.Domain.Dtos.Posts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Web.API.Controllers.Posts
{
    [Produces("application/json")]
    [Route("api/TempPosts")]
    [EnableCors("CorsPolicy")]
    public class TempPostsController : Controller
    {
        private readonly ITempPostsService tempPostsService;
       
        public TempPostsController(ITempPostsService tempPostsService)
        {
            this.tempPostsService = tempPostsService;
        }

        [HttpPut("Create")]
        public async Task<ResponseDto> Create([FromBody]TempPostsDto postsDto)
        {
            return await this.tempPostsService.CreateTempPost(postsDto);
        }

        [HttpPost("Update")]
        public async Task<ResponseDto> Update(int postId, [FromBody]TempPostsDto postsDto)
        {
            return await this.tempPostsService.UpdateTempPost(postId, postsDto);
        }

        [HttpDelete("Delete")]
        public async Task<ResponseDto> Delete(int postId)
        {
            return await this.tempPostsService.DeleteTempPost(postId);
        }

        [HttpGet("Post")]
        public async Task<TempPostsDto> GetPost(int postId)
        {
            return await this.tempPostsService.GetTempPost(postId);
        }

        [HttpGet("UserPosts")]
        public async Task<IEnumerable<TempPostsDto>> GetUserPosts([FromQuery]SearchCriteriaDto searchCriteriaDto, int userId)
        {
            return await this.tempPostsService.GetTempPosts(searchCriteriaDto, userId);
        }
    }
}