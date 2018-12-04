using ECodeWorld.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public class PostCategoryRepository : IPostCategoryRepository
    {
        private readonly ECodeWorldContext eCodeWorldContext;
        public PostCategoryRepository()
        {
            eCodeWorldContext = new ECodeWorldContext();
        }
        public PostCategoryRepository(string connectionString, TimeSpan cacheTimespan)
        {
            eCodeWorldContext = new ECodeWorldContext(connectionString, cacheTimespan);
        }
        public async Task<IEnumerable<PostsCategories>> GetPostCategories(SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
                return null;
            if (searchCriteria.IsOrderByDescending)
            {
                return await eCodeWorldContext.PostsCategories.
                       OrderByDescending(p => p.Id).
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
            else
            {
                return await eCodeWorldContext.PostsCategories.
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
        }

        public async Task<PostsCategories> GetPostCategory(int categoryId)
        {
            return await eCodeWorldContext.PostsCategories.FirstOrDefaultAsync(p => p.Id == categoryId);
        }
    }
}
