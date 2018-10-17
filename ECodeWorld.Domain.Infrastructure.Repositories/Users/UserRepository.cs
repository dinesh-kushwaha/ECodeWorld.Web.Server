using ECodeWorld.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Infrastructure.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ECodeWorldContext eCodeWorldContext;

        public UserRepository()
        {
            eCodeWorldContext = new ECodeWorldContext();
        }
        public UserRepository(string connectionString, TimeSpan cacheTimespan)
        {
            eCodeWorldContext = new ECodeWorldContext(connectionString, cacheTimespan);
        }



        public async Task<Users> GetUserByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return null;
            else
                return eCodeWorldContext.Users.Include(u => u.UsersGroups).FirstOrDefault(u => u.UserName == userName);

        }

        public async Task<UsersProfiles> GetUserProfile(string userName)
        {
            var login = eCodeWorldContext.Logins.FirstOrDefault(l => l.UserName == userName);
            if (login == null)
                return null;
            return eCodeWorldContext.UsersProfiles.FirstOrDefault(l => l.UsersId == login.UsersId);
        }

        public async Task<UsersProfiles> GetUserProfileById(int userId)
        {
            var login = eCodeWorldContext.Logins.FirstOrDefault(l => l.UsersId == userId);
            if (login == null)
                return null;
            return eCodeWorldContext.UsersProfiles.FirstOrDefault(l => l.UsersId == login.UsersId);
        }

        public async Task<IEnumerable<UsersProfiles>> GetUserProfiles(int profileType = 0)
        {
            return eCodeWorldContext.UsersProfiles;
        }

        public async Task<int> UpdateUserProfile(UsersProfiles userProfiles)
        {
            var userProfile = await GetUserProfileById((int)userProfiles.UsersId);
            if (userProfile == null)
            {
                eCodeWorldContext.UsersProfiles.Add(userProfiles);
            }
            else
            {
                eCodeWorldContext.UsersProfiles.Update(userProfiles);
            }
            return await eCodeWorldContext.SaveChangesAsync();
        }

        public async Task<int> CreateLogin(Logins logins)
        {
            logins.Users = new Users { UserName = logins.UserName };
            eCodeWorldContext.Logins.Add(logins);
            return await eCodeWorldContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<GroupsRoles>> GetGroupsRoles(int groupId)
        {
            return await eCodeWorldContext.GroupsRoles
                .Include(gr => gr.Groups)
                .Include(gr => gr.Roles.RolesPermissions)
                .Where(gr => gr.GroupsId == groupId)
                .ToListAsync();
        }

        public async Task<IEnumerable<RolesPermissions>> GetRolesPermissions(int roleId)
        {
            return await eCodeWorldContext.RolesPermissions
                .Include(r => r.Ecwresources)
                .Include(r => r.Permissions)
                .Where(rp => rp.RolesId == roleId)
                .ToListAsync();
        }
    }
}
