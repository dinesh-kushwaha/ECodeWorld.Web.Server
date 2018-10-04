using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using M = ECodeWorld.Domain.Entities.Models;
namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public interface IPostsComplexityRepository
    {
        Task<M.ComplexityLevels> GetPostComplexityLevel(int complexityLevelId);
        Task<IEnumerable<M.ComplexityLevels>> GetComplexityLevels(SearchCriteria searchCriteria);
    }
}
