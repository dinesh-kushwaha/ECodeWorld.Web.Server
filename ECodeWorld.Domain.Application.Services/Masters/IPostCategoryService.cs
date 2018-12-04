using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Masters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Masters
{
    public interface IPostCategoryService
    {
        Task<PostsCategoriesDto> GetPostCategory(int categoryId);
        Task<IEnumerable<PostsCategoriesDto>> GetPostCategories(SearchCriteriaDto searchCriteriaDto);
    }
}
