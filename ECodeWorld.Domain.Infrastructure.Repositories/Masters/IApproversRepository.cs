using System.Collections.Generic;
using System.Threading.Tasks;
using ECodeWorld.Domain.Entities.Models;
namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public interface IApproversRepository
    {
        Task<PostCategories> GetApprover(int approverId);
        Task<IEnumerable<PostCategories>> GetApprovers(SearchCriteria searchCriteria);
    }
}

