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

        public async Task<Users> GetUser(int userId)
        {
            return eCodeWorldContext.Users.Include(u => u.UsersGroups).
                Include(u => u.UsersProfiles).
                //Include(u => u.UsersQualifications.Select(x => x.Qualifications)).
                //Include(u => u.UsersCertifications.Select(x => x.Certifications)).
                Include(u => u.UsersQualifications).
                Include(u => u.UsersCertifications).
                Include(u => u.UsersAddress).
                Include(u => u.UsersPolicies).
                Include(u => u.UsersPolicies).FirstOrDefault(u => u.Id == userId);

        }

        public async Task<UsersProfiles> GetUserProfile(int userId)
        {
            return await eCodeWorldContext.UsersProfiles.FirstOrDefaultAsync(u => u.Id == userId);

        }

        public async Task<IEnumerable<UsersProfiles>> GetUserProfiles(bool isWebUser)
        {
            return await eCodeWorldContext.UsersProfiles.Join(eCodeWorldContext.Users,
                up => up.UsersId,
                u => u.Id,
                (up, u) => new { userProfile = up, user = u }).
                Where(upu => upu.user.IsWebUser == isWebUser).
                Select(s => s.userProfile).ToListAsync();

        }

        public async Task<Users> GetUserByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return null;
            else
                return eCodeWorldContext.Users.Include(u => u.UsersGroups).FirstOrDefault(u => u.UserName == userName);

        }

        public async Task<int> UpdateUserProfile(UsersProfiles newUserProfiles)
        {
            var oldUserProfile = await eCodeWorldContext.UsersProfiles.FirstOrDefaultAsync(x => x.UsersId == newUserProfiles.UsersId);
            if (oldUserProfile == null)
            {
                eCodeWorldContext.UsersProfiles.Add(newUserProfiles);
            }
            else
            {
                oldUserProfile.FirstName = newUserProfiles.FirstName;
                oldUserProfile.MiddleName = newUserProfiles.MiddleName;
                oldUserProfile.LastName = newUserProfiles.LastName;
                oldUserProfile.DisplayName = $"{newUserProfiles.FirstName} {newUserProfiles.MiddleName} { newUserProfiles.LastName}";
                oldUserProfile.Title = newUserProfiles.Title;
                oldUserProfile.CompanyName = newUserProfiles.CompanyName;
                oldUserProfile.HighestQualification = newUserProfiles.HighestQualification;
                oldUserProfile.Description = newUserProfiles.Description;
                oldUserProfile.Description = newUserProfiles.Description;
                oldUserProfile.AboutMe = newUserProfiles.AboutMe;
                oldUserProfile.Avtar = newUserProfiles.Avtar;
                eCodeWorldContext.UsersProfiles.Update(oldUserProfile);
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
