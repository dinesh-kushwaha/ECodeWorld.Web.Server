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
        private readonly IPostsStatusMapper postStatusMapper;
        public PostsStatusService(IPostStatusRepository postStatusRepository, IPostsStatusMapper postStatusMapper)
        {
            this.postStatusRepository = postStatusRepository;
            this.postStatusMapper = postStatusMapper;
        }

        public async Task<PostsStatusDto> GetPostStatus(int postStatusId)
        {
            var entity = await this.postStatusRepository.GetPostStatus(postStatusId);
            return this.postStatusMapper.Configuration.Map<PostsStatusDto>(entity);
        }

        public async Task<IEnumerable<PostsStatusDto>> GetPostStatuss(SearchCriteriaDto searchCriteriaDto)
        {
            var searchCriteria = this.postStatusMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.postStatusRepository.GetPostStatuss(searchCriteria);
            return this.postStatusMapper.Configuration.Map<IEnumerable<PostsStatusDto>>(entities);
        }
    }
}
