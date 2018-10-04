using ECodeWorld.Domain.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Infrastructure.Repositories.User
{
    public interface IUserRepository
    {
        Task<Users> GetUserByUserName(string userName);
        Task<UserProfiles> GetUserProfile(string userName);
        Task<UserProfiles> GetUserProfileById(int userId);
        Task<IEnumerable<UserProfiles>> GetUserProfiles(int profileType = 0);
        Task<int> UpdateUserProfile(UserProfiles userProfiles);
        Task<int> CreateLogin(Logins logins);
    }
}
