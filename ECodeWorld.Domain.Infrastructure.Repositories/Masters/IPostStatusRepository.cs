using System.Collections.Generic;
using System.Threading.Tasks;
using M = ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public interface IPostStatusRepository
    {
        Task<M.PostStatus> GetPostStatus(int postStatusId);
        Task<IEnumerable<M.PostStatus>> GetPostStatuss(SearchCriteria searchCriteria);
    }
}
