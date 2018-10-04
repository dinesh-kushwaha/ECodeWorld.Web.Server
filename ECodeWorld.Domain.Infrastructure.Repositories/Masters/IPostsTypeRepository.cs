using System.Collections.Generic;
using System.Threading.Tasks;
using M = ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public interface IPostsTypeRepository
    {
        Task<M.PostTypes> GetPostType(int postTypesId);
        Task<IEnumerable<M.PostTypes>> GetPostTypes(SearchCriteria searchCriteria);
    }
}
