using ECodeWorld.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public class PostStatusRepository : IPostStatusRepository
    {
        private readonly ECodeWorldContext eCodeWorldContext;
        public PostStatusRepository()
        {
            eCodeWorldContext = new ECodeWorldContext();
        }
        public PostStatusRepository(string connectionString, TimeSpan cacheTimespan)
        {
            eCodeWorldContext = new ECodeWorldContext(connectionString, cacheTimespan);
        }
        public async Task<PostsStatus> GetPostStatus(int postStatusId)
        {
            return await eCodeWorldContext.PostsStatus.FirstOrDefaultAsync(p => p.Id == postStatusId);
        }

        public async Task<IEnumerable<PostsStatus>> GetPostStatuss(SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
                return null;
            if (searchCriteria.IsOrderByDescending)
            {
                return await eCodeWorldContext.PostsStatus.
                       OrderByDescending(p => p.Id).
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
            else
            {
                return await eCodeWorldContext.PostsStatus.
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
        }
    }
}
