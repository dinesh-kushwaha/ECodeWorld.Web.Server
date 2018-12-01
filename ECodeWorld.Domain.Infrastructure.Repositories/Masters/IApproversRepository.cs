using System.Collections.Generic;
using System.Threading.Tasks;
using ECodeWorld.Domain.Entities.CustomModels;
using ECodeWorld.Domain.Entities.Models;
using ECodeWorld.Domain.Infrastructure.Repositories.SearchCriteriaModels;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public interface IApproversRepository
    {
        Task<ApproverTypes> GetApprover(int approverTypeId);
        Task<IEnumerable<ApproverTypes>> GetApprovers(SearchCriteria searchCriteria);
        Task<IEnumerable<ApproversMembersModel>> GetApproversMembers(ApproversMembersSC searchCriteria);
    }
}

