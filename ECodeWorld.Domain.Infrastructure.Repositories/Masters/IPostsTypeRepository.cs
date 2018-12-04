using System.Collections.Generic;
using System.Threading.Tasks;
using ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public interface IPostsTypeRepository
    {
        Task<PostsTypes> GetPostType(int postTypesId);
        Task<IEnumerable<PostsTypes>> GetPostTypes(SearchCriteria searchCriteria);
    }
}
