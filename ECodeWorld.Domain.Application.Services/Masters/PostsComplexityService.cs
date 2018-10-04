using ECodeWorld.Domain.CrossCutting.Adapters.Masters;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Entities.Models;
using ECodeWorld.Domain.Infrastructure.Repositories;
using ECodeWorld.Domain.Infrastructure.Repositories.Masters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Masters
{
    public class PostsComplexityService : IPostsComplexityService
    {
        private readonly IPostsComplexityRepository postsComplexityRepository;
        private readonly IPostsComplexityMapper postsComplexityMapper;
        public PostsComplexityService(IPostsComplexityRepository postsComplexityRepository, IPostsComplexityMapper postsComplexityMapper)
        {
            this.postsComplexityRepository = postsComplexityRepository;
            this.postsComplexityMapper = postsComplexityMapper;
        }
        public async Task<IEnumerable<ComplexityLevelsDto>> GetComplexityLevels(SearchCriteriaDto searchCriteriaDto)
        {
            var searchCriteria = this.postsComplexityMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.postsComplexityRepository.GetComplexityLevels(searchCriteria);
            return this.postsComplexityMapper.Configuration.Map<IEnumerable<ComplexityLevelsDto>>(entities);
        }

        public async Task<ComplexityLevelsDto> GetPostComplexityLevel(int complexityLevelId)
        {
            var entity = await this.postsComplexityRepository.GetPostComplexityLevel(complexityLevelId);
            return this.postsComplexityMapper.Configuration.Map<ComplexityLevelsDto>(entity);
        }
    }
}
