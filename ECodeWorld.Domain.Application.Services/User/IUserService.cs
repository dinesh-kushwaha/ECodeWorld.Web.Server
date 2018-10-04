using ECodeWorld.Domain.Application.Services.Core;
using ECodeWorld.Domain.Dtos.Message;
using ECodeWorld.Domain.Dtos.Users;
using ECodeWorld.Domain.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.User
{
    public interface IUserService : IService
    {
        Task<Users> GetUserByUserName(string userName);
        Task<UserProfileDto> GetUserProfile(string userName);
        Task<UserProfileDto> GetUserProfileById(int userId);
        Task<IEnumerable<UserProfileDto>> GetUserProfiles(int profileType = 0);
        Task<ResponseDto> UpdateUserProfile(UserProfileDto userProfileDto);
        Task<UserDto> CreateUser(UserDto userDto);

    }
}
