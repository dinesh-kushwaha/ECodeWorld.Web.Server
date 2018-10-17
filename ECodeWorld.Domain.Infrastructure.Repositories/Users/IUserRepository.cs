using ECodeWorld.Domain.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Infrastructure.Repositories.User
{
    public interface IUserRepository
    {
        Task<Users> GetUserByUserName(string userName);
        Task<UsersProfiles> GetUserProfile(string userName);
        Task<UsersProfiles> GetUserProfileById(int userId);
        Task<IEnumerable<UsersProfiles>> GetUserProfiles(int profileType = 0);
        Task<int> UpdateUserProfile(UsersProfiles userProfiles);
        Task<int> CreateLogin(Logins logins);

        Task<IEnumerable<GroupsRoles>> GetGroupsRoles(int groupId);
        Task<IEnumerable<RolesPermissions>> GetRolesPermissions(int roleId);
    }
}
