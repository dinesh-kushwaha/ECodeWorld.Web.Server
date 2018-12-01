using ECodeWorld.Domain.CrossCutting.Adapters.Masters;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Dtos.SearchCriteriaDtos;
using ECodeWorld.Domain.Infrastructure.Repositories;
using ECodeWorld.Domain.Infrastructure.Repositories.Masters;
using ECodeWorld.Domain.Infrastructure.Repositories.SearchCriteriaModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Masters
{

    public class ApproversService : IApproversService
    {
        private readonly IApproversRepository approversRepository;
        private readonly IApproversMapper approversMapper;
        public ApproversService(IApproversRepository approversRepository, IApproversMapper approversMapper)
        {
            this.approversRepository = approversRepository;
            this.approversMapper = approversMapper;
        }

        public async Task<ApproverTypesDto> GetApproverType(int approverTypeId)
        {
            var entity = await this.approversRepository.GetApprover(approverTypeId);
            return this.approversMapper.Configuration.Map<ApproverTypesDto>(entity);
        }

        public async Task<IEnumerable<ApproverTypesDto>> GetApproverTypes(SearchCriteriaDto searchCriteriaDto)
        {
            var searchCriteria= this.approversMapper.Configuration.Map<SearchCriteria>(searchCriteriaDto);
            var entities = await this.approversRepository.GetApprovers(searchCriteria);
            return this.approversMapper.Configuration.Map<IEnumerable<ApproverTypesDto>>(entities);
        }

        public async Task<IEnumerable<ApproversMembersDto>> GetApprovers(ApproversMembersSCDto searchCriteriaDto)
        {
            var searchCriteria = this.approversMapper.Configuration.Map<ApproversMembersSC>(searchCriteriaDto);
            var entities = await this.approversRepository.GetApproversMembers(searchCriteria);
            return this.approversMapper.Configuration.Map<IEnumerable<ApproversMembersDto>>(entities);
        }

    }
}
