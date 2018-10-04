using System.Collections.Generic;
using System.Threading.Tasks;
using M = ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public interface IPostCategoryRepository
    {
        Task<M.PostCategories> GetPostCategory(int categoryId);
        Task<IEnumerable<M.PostCategories>> GetPostCategories(SearchCriteria searchCriteria);
    }
}
