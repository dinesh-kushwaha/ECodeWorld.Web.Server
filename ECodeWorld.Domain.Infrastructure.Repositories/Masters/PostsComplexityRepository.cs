using ECodeWorld.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public class PostsComplexityRepository : IPostsComplexityRepository
    {
        private readonly ECodeWorldContext eCodeWorldContext;
        public PostsComplexityRepository()
        {
            eCodeWorldContext = new ECodeWorldContext();
        }
        public PostsComplexityRepository(string connectionString, TimeSpan cacheTimespan)
        {
            eCodeWorldContext = new ECodeWorldContext(connectionString, cacheTimespan);
        }
        public async Task<IEnumerable<ComplexityLevels>> GetComplexityLevels(SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
                return null;
            if (searchCriteria.IsOrderByDescending)
            {
                return await eCodeWorldContext.ComplexityLevels.
                       OrderByDescending(p => p.Id).
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
            else
            {
                return await eCodeWorldContext.ComplexityLevels.
                       Skip(searchCriteria.PageSize * (searchCriteria.PageNumber - 1)).
                       Take(searchCriteria.PageSize).ToListAsync();
            }
        }

        public async Task<ComplexityLevels> GetPostComplexityLevel(int complexityLevelId)
        {
            return await eCodeWorldContext.ComplexityLevels.FirstOrDefaultAsync(p => p.Id == complexityLevelId);
        }
    }
}
