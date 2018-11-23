using ECodeWorld.Domain.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Accounts
{
    public interface IAccountsService
    {
        Task<AccountsDto> GetAccounts(int userId);
        Task<UsersProfilesDto> GetMember(int memberId);
        Task<IEnumerable<UsersProfilesDto>> GetMembers(bool isWebUser);
    }
}
