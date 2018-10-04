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
        public async Task<PostStatus> GetPostStatus(int postStatusId)
        {
            return await eCodeWorldContext.PostStatus.FirstOrDefaultAsync(p => p.Id == postStatusId);
        }

        public async Task<IEnumerable<PostStatus>> GetPostStatuss(SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
                return null;
            if (searchCriteria.IsOrderByDescending)
            {
                return await eCodeWorldContext.PostStatus.
                       OrderByDescending(p => p.Id).
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
            else
            {
                return await eCodeWorldContext.PostStatus.
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
        }
    }
}
