using ECodeWorld.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public class PostsTypeRepository : IPostsTypeRepository
    {
        private readonly ECodeWorldContext eCodeWorldContext;
        public PostsTypeRepository()
        {
            eCodeWorldContext = new ECodeWorldContext();
        }
        public PostsTypeRepository(string connectionString, TimeSpan cacheTimespan)
        {
            eCodeWorldContext = new ECodeWorldContext(connectionString, cacheTimespan);
        }
        public async Task<PostsTypes> GetPostType(int postTypesId)
        {
            return await eCodeWorldContext.PostsTypes.FirstOrDefaultAsync(p => p.Id == postTypesId);
        }

        public async Task<IEnumerable<PostsTypes>> GetPostTypes(SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
                return null;
            if (searchCriteria.IsOrderByDescending)
            {
                return await eCodeWorldContext.PostsTypes.
                       OrderByDescending(p => p.Id).
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
            else
            {
                return await eCodeWorldContext.PostsTypes.
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
        }
    }
}
