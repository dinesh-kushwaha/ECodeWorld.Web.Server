using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Masters
{
    public interface IPostsTypeService
    {
        Task<PostsTypesDto> GetPostType(int postTypesId);
        Task<IEnumerable<PostsTypesDto>> GetPostTypes(SearchCriteriaDto searchCriteriaDto);
    }
}
