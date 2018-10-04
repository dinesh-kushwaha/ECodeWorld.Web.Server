using ECodeWorld.Domain.CrossCutting.Adapters.Posts;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Message;
using ECodeWorld.Domain.Dtos.Posts;
using ECodeWorld.Domain.Infrastructure.Repositories;
using ECodeWorld.Domain.Infrastructure.Repositories.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;
using M = ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.Application.Services.Posts
{
    public class TempPostsService : ITempPostsService
    {
        private readonly IPostsRepository userRepository;
        private readonly IPostsMapper postsMapper;
        public TempPostsService(IPostsRepository userRepository, IPostsMapper postsMapper)
        {
            this.userRepository = userRepository;
            this.postsMapper = postsMapper;
        }

        public async Task<ResponseDto> CreateTempPost(TempPostsDto posts)
        {
            var entity = this.postsMapper.Configuration.Map<M.TempPosts>(posts);
            await this.userRepository.CreateTempPost(entity);
            return new ResponseDto { };
        }

        public async Task<ResponseDto> UpdateTempPost(int postId, TempPostsDto posts)
        {
            var entity = this.postsMapper.Configuration.Map<M.TempPosts>(posts);
            await this.userRepository.UpdateTempPost(postId, entity);
            return new ResponseDto { };
        }
        public async Task<ResponseDto> DeleteTempPost(int postId)
        {
            await this.userRepository.DeleteTempPost(postId);
            return new ResponseDto { };
        }

        public async Task<TempPostsDto> GetTempPost(int postId)
        {
            var entity = await this.userRepository.GetTempPost(postId);
            return this.postsMapper.Configuration.Map<TempPostsDto>(entity);
        }

        public async Task<IEnumerable<TempPostsDto>> GetTempPosts(SearchCriteriaDto searchCriteriaDto, int userId)
        {
            var searchCriteria = this.postsMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.userRepository.GetTempPosts(searchCriteria, userId);
            return this.postsMapper.Configuration.Map<IEnumerable<TempPostsDto>>(entities);
        }

        
    }
}
