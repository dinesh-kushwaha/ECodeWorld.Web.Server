using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using System.Collections.Generic;
using System.Threading.Tasks;
using M = ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.Application.Services.Masters
{
    public interface IPostsStatusService
    {
        Task<PostStatusDto> GetPostStatus(int postStatusId);
        Task<IEnumerable<PostStatusDto>> GetPostStatuss(SearchCriteriaDto searchCriteriaDto);
    }
}
