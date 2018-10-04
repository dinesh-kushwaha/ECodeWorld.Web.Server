using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Message;
using ECodeWorld.Domain.Dtos.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Posts
{
    public interface ITempPostsService
    {
        Task<ResponseDto> CreateTempPost(TempPostsDto posts);
        Task<ResponseDto> UpdateTempPost(int postId, TempPostsDto posts);
        Task<ResponseDto> DeleteTempPost(int postId);

        Task<TempPostsDto> GetTempPost(int postId);
        Task<IEnumerable<TempPostsDto>> GetTempPosts(SearchCriteriaDto searchCriteriaDto, int userId);
    }
}
