using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using System.Collections.Generic;
using System.Threading.Tasks;
using M = ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.Application.Services.Masters
{
    public interface IPostsStatusService
    {
        Task<PostsStatusDto> GetPostStatus(int postStatusId);
        Task<IEnumerable<PostsStatusDto>> GetPostStatuss(SearchCriteriaDto searchCriteriaDto);
    }
}
