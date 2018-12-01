using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Dtos.SearchCriteriaDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Masters
{

    public interface IApproversService
    {
        Task<ApproverTypesDto> GetApproverType(int approverTypeId);
        Task<IEnumerable<ApproverTypesDto>> GetApproverTypes(SearchCriteriaDto searchCriteria);
        Task<IEnumerable<ApproversMembersDto>> GetApprovers(ApproversMembersSCDto searchCriteria);
    }
}
