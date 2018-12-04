using ECodeWorld.Domain.Application.Services.Masters;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Dtos.SearchCriteriaDtos;
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
        private readonly IApproversService approversService;

        public MasterController(IPostCategoryService postCategoryService,
            IPostsComplexityService postsComplexityService,
            IPostsTypeService postsTypeService,
            IPostsStatusService postsStatusService,
            IApproversService approversService
            )
        {
            this.postCategoryService = postCategoryService;
            this.postsComplexityService = postsComplexityService;
            this.postsTypeService = postsTypeService;
            this.postsStatusService = postsStatusService;
            this.approversService = approversService;
        }

        [HttpGet("PostCategories")]
        public async Task<IEnumerable<PostsCategoriesDto>> GetCategories([FromQuery]SearchCriteriaDto searchCriteriaDto)
        {
            return await this.postCategoryService.GetPostCategories(searchCriteriaDto);
        }

        [HttpGet("PostCategory")]
        public async Task<PostsCategoriesDto> GetCategory(int categoryId)
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
        public async Task<IEnumerable<PostsTypesDto>> GetPostTypes([FromQuery]SearchCriteriaDto searchCriteriaDto)
        {
            return await this.postsTypeService.GetPostTypes(searchCriteriaDto);
        }

        [HttpGet("PostType")]
        public async Task<PostsTypesDto> GetPostType(int postTypeId)
        {
            return await this.postsTypeService.GetPostType(postTypeId);
        }

        [HttpGet("PostStatuss")]
        public async Task<IEnumerable<PostsStatusDto>> GetPostStatuss([FromQuery]SearchCriteriaDto searchCriteriaDto)
        {
            return await this.postsStatusService.GetPostStatuss(searchCriteriaDto);
        }

        [HttpGet("PostStatus")]
        public async Task<PostsStatusDto> GetPostStatus(int postStatusId)
        {
            return await this.postsStatusService.GetPostStatus(postStatusId);
        }

        [HttpGet("GetApprovers")]
        public async Task<IEnumerable<ApproversMembersDto>> GetApprovers([FromQuery]ApproversMembersSCDto searchCriteriaDto)
        {
            return await this.approversService.GetApprovers(searchCriteriaDto);
        }
        [HttpGet("GetApproverTypes")]
        public async Task<IEnumerable<ApproverTypesDto>> GetApproversTypes([FromQuery]SearchCriteriaDto searchCriteriaDto)
        {
            return await this.approversService.GetApproverTypes(searchCriteriaDto);
        }

        [HttpGet("GetApproverType")]
        public async Task<ApproverTypesDto> GetApproversTypes(int approverTypeId)
        {
            return await this.approversService.GetApproverType(approverTypeId);
        }
    }
}