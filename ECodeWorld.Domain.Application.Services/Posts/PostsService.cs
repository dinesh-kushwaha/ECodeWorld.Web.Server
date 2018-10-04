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
    public class PostsService : IPostsService
    {
        private readonly IPostsRepository userRepository;
        private readonly IPostsMapper postsMapper;
        public PostsService(IPostsRepository userRepository, IPostsMapper postsMapper)
        {
            this.userRepository = userRepository;
            this.postsMapper = postsMapper;
        }

        public async Task<ResponseDto> CreatePost(PostsDto posts)
        {
            var entity = this.postsMapper.Configuration.Map<M.Posts>(posts);
            await this.userRepository.CreatePost(entity);
            return new ResponseDto { };

        }

        public async Task<ResponseDto> DeletePost(int postId)
        {
            await this.userRepository.DeletePost(postId);
            return new ResponseDto { };
        }

        public async Task<IEnumerable<PostsDto>> GetMostViewdPosts(SearchCriteriaDto searchCriteriaDto)
        {
            var searchCriteria = this.postsMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.userRepository.GetMostViewdPosts(searchCriteria);
            return this.postsMapper.Configuration.Map<IEnumerable<PostsDto>>(entities);
        }

        public async Task<PostsDto> GetPost(int postId)
        {
            var entity = await this.userRepository.GetPost(postId);
            return this.postsMapper.Configuration.Map<PostsDto>(entity);
        }

        public async Task<IEnumerable<PostsDto>> GetUserPosts(SearchCriteriaDto searchCriteriaDto, int userId)
        {
            var searchCriteria = this.postsMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.userRepository.GetUserPosts(searchCriteria, userId);
            return this.postsMapper.Configuration.Map<IEnumerable<PostsDto>>(entities);
        }

        public async Task<IEnumerable<PostsDto>> GetPosts(SearchCriteriaDto searchCriteriaDto)
        {
            var searchCriteria = this.postsMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.userRepository.GetPosts(searchCriteria);
            return this.postsMapper.Configuration.Map<IEnumerable<PostsDto>>(entities);
        }

        public async Task<IEnumerable<PostsDto>> GetRecentPosts(SearchCriteriaDto searchCriteriaDto)
        {
            var searchCriteria = this.postsMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.userRepository.GetRecentPosts(searchCriteria);
            return this.postsMapper.Configuration.Map<IEnumerable<PostsDto>>(entities);
        }
        public async Task<IEnumerable<PostsDto>> GetTopPosts(SearchCriteriaDto searchCriteriaDto)
        {
            var searchCriteria = this.postsMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.userRepository.GetTopPosts(searchCriteria);
            return this.postsMapper.Configuration.Map<IEnumerable<PostsDto>>(entities);
        }

        public async Task<ResponseDto> UpdatePost(int postId, PostsDto posts)
        {
            var entity = this.postsMapper.Configuration.Map<M.Posts>(posts);
            await this.userRepository.UpdatePost(postId, entity);
            return new ResponseDto { };
        }
    }
}
