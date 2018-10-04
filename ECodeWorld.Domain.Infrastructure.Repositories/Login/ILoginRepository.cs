using ECodeWorld.Domain.Entities.Models;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Infrastructure.Repositories.Authentication
{
    public interface ILoginRepository
    {
        Task<Logins> GetLogin(string userName);
        Task<int> CreateLogin(Users logins);
    }
}
