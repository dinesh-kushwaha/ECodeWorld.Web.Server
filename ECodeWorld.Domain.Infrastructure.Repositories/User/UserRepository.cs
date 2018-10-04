using ECodeWorld.Domain.Entities.Models;
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
                return eCodeWorldContext.Users.FirstOrDefault(u => u.UserName == userName);

        }

        public async Task<UserProfiles> GetUserProfile(string userName)
        {
            var login = eCodeWorldContext.Logins.FirstOrDefault(l => l.UserName == userName);
            if (login == null)
                return null;
            return eCodeWorldContext.UserProfiles.FirstOrDefault(l => l.UsersId == login.UsersId);
        }

        public async Task<UserProfiles> GetUserProfileById(int userId)
        {
            var login = eCodeWorldContext.Logins.FirstOrDefault(l => l.UsersId == userId);
            if (login == null)
                return null;
            return eCodeWorldContext.UserProfiles.FirstOrDefault(l => l.UsersId == login.UsersId);
        }

        public async Task<IEnumerable<UserProfiles>> GetUserProfiles(int profileType = 0)
        {
            return eCodeWorldContext.UserProfiles;
        }

        public async Task<int> UpdateUserProfile(UserProfiles userProfiles)
        {
            var userProfile = await GetUserProfileById((int)userProfiles.UsersId);
            if (userProfile == null)
            {
                eCodeWorldContext.UserProfiles.Add(userProfiles);
            }
            else
            {
                eCodeWorldContext.UserProfiles.Update(userProfiles);
            }
            return await eCodeWorldContext.SaveChangesAsync();
        }

        public async Task<int> CreateLogin(Logins logins)
        {
            logins.Users = new Users { UserName = logins.UserName };
            eCodeWorldContext.Logins.Add(logins);
            return await eCodeWorldContext.SaveChangesAsync();
        } 
    }
}
