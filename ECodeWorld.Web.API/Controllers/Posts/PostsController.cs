using ECodeWorld.Domain.Application.Services.Posts;
using ECodeWorld.Domain.CrossCutting.Adapters.Posts;
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
    [Route("api/Posts")]
    [EnableCors("CorsPolicy")]
    public class PostsController : Controller
    {
        private readonly IPostsService postsService;
        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpPut("Create")]
        public async Task<ResponseDto> Create([FromBody]PostsDto postsDto)
        {
            return await this.postsService.CreatePost(postsDto);
        }

        [HttpPost("Update")]
        public async Task<ResponseDto> Update(int postId, [FromBody]PostsDto postsDto)
        {
            return await this.postsService.UpdatePost(postId, postsDto);
        }

        [HttpDelete("Delete")]
        public async Task<ResponseDto> Delete(int postId)
        {
            return await this.postsService.DeletePost(postId);
        }

        [HttpGet("Post")]
        public async Task<PostsDto> GetPost(int postId)
        {
            return await this.postsService.GetPost(postId);
        }

        [HttpGet("UserPosts")]
        public async Task<IEnumerable<PostsDto>> GetUserPosts([FromQuery]SearchCriteriaDto searchCriteriaDto, int userId)
        {
            return await this.postsService.GetUserPosts(searchCriteriaDto, userId);
        }

        [HttpGet("Posts")]
        public async Task<IEnumerable<PostsDto>> GetPosts([FromQuery]SearchCriteriaDto searchCriteriaDto)
        {
            return await this.postsService.GetPosts(searchCriteriaDto);
        }

        [HttpGet("TopPosts")]
        public async Task<IEnumerable<PostsDto>> GetTopPosts([FromQuery]SearchCriteriaDto searchCriteriaDto, int userId)
        {
            return await this.postsService.GetTopPosts(searchCriteriaDto);
        }

        [HttpGet("RecentPosts")]
        public async Task<IEnumerable<PostsDto>> GetRecentPosts([FromQuery]SearchCriteriaDto searchCriteriaDto)
        {
            return await this.postsService.GetRecentPosts(searchCriteriaDto);
        }
    }
}