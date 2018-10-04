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
        public async Task<IEnumerable<PostCategories>> GetPostCategories(SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
                return null;
            if (searchCriteria.IsOrderByDescending)
            {
                return await eCodeWorldContext.PostCategories.
                       OrderByDescending(p => p.Id).
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
            else
            {
                return await eCodeWorldContext.PostCategories.
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
        }

        public async Task<PostCategories> GetPostCategory(int categoryId)
        {
            return await eCodeWorldContext.PostCategories.FirstOrDefaultAsync(p => p.Id == categoryId);
        }
    }
}
