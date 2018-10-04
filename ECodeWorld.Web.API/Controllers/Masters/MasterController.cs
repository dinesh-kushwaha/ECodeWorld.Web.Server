using ECodeWorld.Domain.Application.Services.Masters;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Web.API.Controllers.Masters
{
    [Produces("application/json")]
    [Route("api/Master")]
    [EnableCors("CorsPolicy")]
    public class MasterController : Controller
    {
        private readonly IPostCategoryService postCategoryService;
        private readonly IPostsComplexityService postsComplexityService;
        private readonly IPostsTypeService postsTypeService;
        private readonly IPostsStatusService postsStatusService;

        public MasterController(IPostCategoryService postCategoryService,
            IPostsComplexityService postsComplexityService,
            IPostsTypeService postsTypeService,
            IPostsStatusService postsStatusService
            )
        {
            this.postCategoryService = postCategoryService;
            this.postsComplexityService = postsComplexityService;
            this.postsTypeService = postsTypeService;
            this.postsStatusService = postsStatusService;
        }

        [HttpGet("PostCategories")]
        public async Task<IEnumerable<PostCategoriesDto>> GetCategories([FromQuery]SearchCriteriaDto searchCriteriaDto)
        {
            return await this.postCategoryService.GetPostCategories(searchCriteriaDto);
        }

        [HttpGet("PostCategory")]
        public async Task<PostCategoriesDto> GetCategory(int categoryId)
        {
            return await this.postCategoryService.GetPostCategory(categoryId);
        }

        [HttpGet("PostComplexityLevels")]
        public async Task<IEnumerable<ComplexityLevelsDto>> GetComplexityLevels([FromQuery]SearchCriteriaDto searchCriteriaDto)
        {
            return await this.postsComplexityService.GetComplexityLevels(searchCriteriaDto);
        }

        [HttpGet("PostComplexityLevel")]
        public async Task<ComplexityLevelsDto> GetComplexityLevel(int complexityLevelId)
        {
            return await this.postsComplexityService.GetPostComplexityLevel(complexityLevelId);
        }

        [HttpGet("PostTypes")]
        public async Task<IEnumerable<PostTypesDto>> GetPostTypes([FromQuery]SearchCriteriaDto searchCriteriaDto)
        {
            return await this.postsTypeService.GetPostTypes(searchCriteriaDto);
        }

        [HttpGet("PostType")]
        public async Task<PostTypesDto> GetPostType(int postTypeId)
        {
            return await this.postsTypeService.GetPostType(postTypeId);
        }

        [HttpGet("PostStatuss")]
        public async Task<IEnumerable<PostStatusDto>> GetPostStatuss([FromQuery]SearchCriteriaDto searchCriteriaDto)
        {
            return await this.postsStatusService.GetPostStatuss(searchCriteriaDto);
        }

        [HttpGet("PostStatus")]
        public async Task<PostStatusDto> GetPostStatus(int postStatusId)
        {
            return await this.postsStatusService.GetPostStatus(postStatusId);
        }
    }
}