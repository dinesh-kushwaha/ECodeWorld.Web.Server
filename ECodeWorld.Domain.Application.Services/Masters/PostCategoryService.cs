using ECodeWorld.Domain.CrossCutting.Adapters.Masters;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Infrastructure.Repositories;
using ECodeWorld.Domain.Infrastructure.Repositories.Masters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Masters
{
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IPostCategoryRepository postCategoryRepository;
        private readonly IPostsCategoryMapper postCategoryMapper;
        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IPostsCategoryMapper postCategoryMapper)
        {
            this.postCategoryRepository = postCategoryRepository;
            this.postCategoryMapper = postCategoryMapper;
        }

        public async Task<IEnumerable<PostsCategoriesDto>> GetPostCategories(SearchCriteriaDto searchCriteriaDto)
        {
            try
            {
                var searchCriteria = this.postCategoryMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
                var entities = await this.postCategoryRepository.GetPostCategories(searchCriteria);
                return this.postCategoryMapper.Configuration.Map<IEnumerable<PostsCategoriesDto>>(entities);
            }
            catch (Exception error)
            {

            }
            return null;
        }

        public async Task<PostsCategoriesDto> GetPostCategory(int categoryId)
        {
            var entity = await this.postCategoryRepository.GetPostCategory(categoryId);
            return this.postCategoryMapper.Configuration.Map<PostsCategoriesDto>(entity);
        }
    }
}
