using ECodeWorld.Domain.CrossCutting.Adapters.Masters;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Infrastructure.Repositories;
using ECodeWorld.Domain.Infrastructure.Repositories.Masters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Masters
{
    public class PostsStatusService : IPostsStatusService
    {
        private readonly IPostStatusRepository postStatusRepository;
        private readonly IPostStatusMapper postStatusMapper;
        public PostsStatusService(IPostStatusRepository postStatusRepository, IPostStatusMapper postStatusMapper)
        {
            this.postStatusRepository = postStatusRepository;
            this.postStatusMapper = postStatusMapper;
        }

        public async Task<PostStatusDto> GetPostStatus(int postStatusId)
        {
            var entity = await this.postStatusRepository.GetPostStatus(postStatusId);
            return this.postStatusMapper.Configuration.Map<PostStatusDto>(entity);
        }

        public async Task<IEnumerable<PostStatusDto>> GetPostStatuss(SearchCriteriaDto searchCriteriaDto)
        {
            var searchCriteria = this.postStatusMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.postStatusRepository.GetPostStatuss(searchCriteria);
            return this.postStatusMapper.Configuration.Map<IEnumerable<PostStatusDto>>(entities);
        }
    }
}
