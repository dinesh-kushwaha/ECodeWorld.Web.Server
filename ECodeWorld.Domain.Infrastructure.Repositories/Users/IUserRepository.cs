using ECodeWorld.Domain.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Infrastructure.Repositories.User
{
    public interface IUserRepository
    {
        Task<Users> GetUser(int userId);
        Task<Users> GetUserByUserName(string userName);
        Task<UsersProfiles> GetUserProfile(int memberId);
       
        Task<IEnumerable<UsersProfiles>> GetUserProfiles(bool isWebUser);
        Task<int> UpdateUserProfile(UsersProfiles userProfiles);
        Task<int> CreateLogin(Logins logins);

        Task<IEnumerable<GroupsRoles>> GetGroupsRoles(int groupId);
        Task<IEnumerable<RolesPermissions>> GetRolesPermissions(int roleId);
    }
}
