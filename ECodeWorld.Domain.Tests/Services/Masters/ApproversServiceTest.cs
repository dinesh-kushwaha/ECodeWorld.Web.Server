using Autofac;
using ECodeWorld.Domain.Application.Services.Masters;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.SearchCriteriaDtos;
using ECodeWorld.Domain.Infrastructure.Repositories;
using ECodeWorld.Domain.Infrastructure.Repositories.SearchCriteriaModels;
using Xunit;


namespace ECodeWorld.Domain.Tests.Services.Masters
{
    public class ApproversServiceTest : ECWTestsBase
    {
        private readonly IApproversService approversService;

        public ApproversServiceTest()
        {
            this.approversService = AutofacContainer.Resolve<IApproversService>();
        }

        [Fact]
        public async void GetApproverTypes()
        {

            
            var data =await this.approversService.GetApproverTypes(new SearchCriteriaDto
            {
                IsOrderByDescending = false,
                PageNumber = 1,
                PageSize = 25
            });
           
        }

        [Fact]
        public async void GetApproversMembers()
        {

            var data = await this.approversService.GetApprovers(new ApproversMembersSCDto
            {
                IsOrderByDescending = false,
                PageNumber = 1,
                PageSize = 25
            });

        }
    }

}
