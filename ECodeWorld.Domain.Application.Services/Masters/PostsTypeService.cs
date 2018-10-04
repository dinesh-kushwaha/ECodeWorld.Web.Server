using ECodeWorld.Domain.CrossCutting.Adapters.Masters;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Infrastructure.Repositories;
using ECodeWorld.Domain.Infrastructure.Repositories.Masters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Masters
{
    public class PostsTypeService : IPostsTypeService
    {
        private readonly IPostsTypeRepository postsTypeRepository;
        private readonly IPostsTypeMapper postsTypeMapper;
        public PostsTypeService(IPostsTypeRepository postsTypeRepository, IPostsTypeMapper postsTypeMapper)
        {
            this.postsTypeRepository = postsTypeRepository;
            this.postsTypeMapper = postsTypeMapper;
        }
        public async Task<PostTypesDto> GetPostType(int postTypesId)
        {
            var entity = await this.postsTypeRepository.GetPostType(postTypesId);
            return this.postsTypeMapper.Configuration.Map<PostTypesDto>(entity);
        }

        public async Task<IEnumerable<PostTypesDto>> GetPostTypes(SearchCriteriaDto searchCriteriaDto)
        {
            var searchCriteria = this.postsTypeMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.postsTypeRepository.GetPostTypes(searchCriteria);
            return this.postsTypeMapper.Configuration.Map<IEnumerable<PostTypesDto>>(entities);
        }
    }
}
