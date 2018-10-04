using System.Collections.Generic;
using System.Threading.Tasks;
using M = ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Posts
{
    public interface IPostsRepository
    {
        Task<M.Posts> GetPost(int postId);
        Task<IEnumerable<M.Posts>> GetUserPosts(SearchCriteria searchCriteria, int userId);
        Task<IEnumerable<M.Posts>> GetPosts(SearchCriteria searchCriteria);
        Task<int> CreatePost(M.Posts posts);
        Task<int> UpdatePost(int postId, M.Posts posts);
        Task<int> DeletePost(int postId);

        Task<IEnumerable<M.Posts>> GetTopPosts(SearchCriteria searchCriteria);
        Task<IEnumerable<M.Posts>> GetRecentPosts(SearchCriteria searchCriteria);
        Task<IEnumerable<M.Posts>> GetMostViewdPosts(SearchCriteria searchCriteria);
        Task<M.Posts> GetPostByUrl(string url);

        Task<int> CreateTempPost(M.TempPosts posts);
        Task<int> UpdateTempPost(int postId, M.TempPosts posts);
        Task<int> DeleteTempPost(int postId);

        Task<M.TempPosts> GetTempPost(int postId);
        Task<IEnumerable<M.TempPosts>> GetTempPosts(SearchCriteria searchCriteria,int userId);
    }
}
