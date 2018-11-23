using ECodeWorld.Domain.CrossCutting.Adapters.Posts;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Core;
using ECodeWorld.Domain.Dtos.Message;
using ECodeWorld.Domain.Dtos.Posts;
using ECodeWorld.Domain.Infrastructure.Repositories;
using ECodeWorld.Domain.Infrastructure.Repositories.Posts;
using ECodeWorld.Domain.Infrastructure.Repositories.User;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using M = ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.Application.Services.Posts
{
    public class TempPostsService : ITempPostsService
    {
        private readonly IPostsRepository postRepository;
        private readonly IUserRepository userRepository;
        private readonly ITempPostsMapper tempPostsMapper;
        
        public TempPostsService(IPostsRepository postRepository,
            IUserRepository userRepository,
            ITempPostsMapper tempPostsMapper)
        {
            this.userRepository = userRepository;
            this.postRepository = postRepository;
            this.tempPostsMapper = tempPostsMapper;
        }
        private string MakeUrlString(string text)
        {
            var array = text.ToCharArray();
            array = Array.FindAll(array, c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-');
            var newString = new string(array).Replace(" ", "-").ToLower();
            return newString;
        }
        private string UrlEncode(string urlText)
        {
            return WebUtility.UrlEncode(urlText);
        }
        public async Task<ResponseDto> CreateTempPost(TempPostsDto posts)
        {
            var responseDto = new ResponseDto { };
            if (posts == null)
                return responseDto;

            try
            {
                posts.PostUrl = UrlEncode(MakeUrlString(posts.Title));
                var entity = this.tempPostsMapper.Configuration.Map<M.TempPosts>(posts);
                var newPostId = await this.postRepository.CreateTempPost(entity);
                if (newPostId > 0)
                {
                    responseDto.Id = newPostId;
                    responseDto.HasError = false;
                    entity.Id = newPostId;
                    responseDto.AddRule("TempPostsDto", "Created !");
                }
                else
                {
                    responseDto.HasError = true;
                    responseDto.AddRule("TempPostsDto", "not Created!");
                }
            }
            catch (Exception error)
            {
                responseDto.HasError = true;
                responseDto.AddRule("Error", error.Message);
            }
            return responseDto;
        }

        public async Task<ResponseDto> UpdateTempPost(int postId, TempPostsDto posts)
        {
            var entity = this.tempPostsMapper.Configuration.Map<M.TempPosts>(posts);
            await this.postRepository.UpdateTempPost(postId, entity);
            return new ResponseDto { };
        }
        public async Task<ResponseDto> DeleteTempPost(int postId)
        {
            await this.postRepository.DeleteTempPost(postId);
            return new ResponseDto { };
        }

        public async Task<TempPostsDto> GetTempPost(int postId)
        {
            var entity = await this.postRepository.GetTempPost(postId);
            return this.tempPostsMapper.Configuration.Map<TempPostsDto>(entity);
        }

        public async Task<IEnumerable<TempPostsDto>> GetTempPosts(SearchCriteriaDto searchCriteriaDto, int userId)
        {
            var searchCriteria = this.tempPostsMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.postRepository.GetTempPosts(searchCriteria, userId);
            return this.tempPostsMapper.Configuration.Map<IEnumerable<TempPostsDto>>(entities);
        }

        public async Task<IEnumerable<TempPostsDto>> GetTempPostssLightWeight(SearchCriteriaDto searchCriteriaDto, int userId)
        {
            var searchCriteria = this.tempPostsMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.postRepository.UserPostsLightWeight(searchCriteria, userId);
            return this.tempPostsMapper.Configuration.Map<IEnumerable<TempPostsDto>>(entities);
        }

        public Task<ResponseDto> TempPostReview(PostReviewersDto postReviewersDto)
        {
            throw new NotImplementedException();
        }
    }
}
