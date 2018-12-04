using System.Collections.Generic;
using System.Threading.Tasks;
using ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Masters
{
    public interface IPostCategoryRepository
    {
        Task<PostsCategories> GetPostCategory(int categoryId);
        Task<IEnumerable<PostsCategories>> GetPostCategories(SearchCriteria searchCriteria);
    }
}
