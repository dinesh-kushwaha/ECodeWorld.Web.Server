using ECodeWorld.Domain.Entities.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Authentication
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ECodeWorldContext eCodeWorldContext;

        public LoginRepository()
        {
            this.eCodeWorldContext = new ECodeWorldContext();
        }
        public LoginRepository(string connectionString, TimeSpan cacheTimespan)
        {
            this.eCodeWorldContext = new ECodeWorldContext(connectionString, cacheTimespan);
        }

        public async Task<int> CreateLogin(Users users)
        {
            await this.eCodeWorldContext.Users.AddAsync(users);
            return await this.eCodeWorldContext.SaveChangesAsync();
        }

        public async Task<Logins> GetLogin(string userName)
        {
            return this.eCodeWorldContext.Logins.FirstOrDefault(l => l.UserName == userName);
        }

    }
}
