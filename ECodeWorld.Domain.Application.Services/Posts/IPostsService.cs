using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Message;
using ECodeWorld.Domain.Dtos.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Posts
{
    public interface IPostsService
    {
        Task<PostsDto> GetPost(int postId);
        Task<IEnumerable<PostsDto>> GetUserPosts(SearchCriteriaDto searchCriteriaDto, int userId);
        Task<IEnumerable<PostsDto>> GetPosts(SearchCriteriaDto searchCriteriaDto);
        Task<ResponseDto> CreatePost(PostsDto posts);
        Task<ResponseDto> UpdatePost(int postId, PostsDto posts);
        Task<ResponseDto> DeletePost(int postId);

        Task<IEnumerable<PostsDto>> GetTopPosts(SearchCriteriaDto searchCriteriaDto);
        Task<IEnumerable<PostsDto>> GetRecentPosts(SearchCriteriaDto searchCriteriaDto);
        Task<IEnumerable<PostsDto>> GetMostViewdPosts(SearchCriteriaDto searchCriteriaDto);
    }
}
