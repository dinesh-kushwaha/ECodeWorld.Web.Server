using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Masters
{
    public interface IPostsTypeService
    {
        Task<PostTypesDto> GetPostType(int postTypesId);
        Task<IEnumerable<PostTypesDto>> GetPostTypes(SearchCriteriaDto searchCriteriaDto);
    }
}
