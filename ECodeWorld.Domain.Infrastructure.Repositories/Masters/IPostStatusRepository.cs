using System.Collections.Generic;
using System.Threading.Tasks;
using ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public interface IPostStatusRepository
    {
        Task<PostsStatus> GetPostStatus(int postStatusId);
        Task<IEnumerable<PostsStatus>> GetPostStatuss(SearchCriteria searchCriteria);
    }
}
