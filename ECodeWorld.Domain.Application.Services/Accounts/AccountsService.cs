using ECodeWorld.Domain.CrossCutting.Adapters.Accounts;
using ECodeWorld.Domain.Dtos.Accounts;
using ECodeWorld.Domain.Infrastructure.Repositories.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Accounts
{
    public class AccountsService : IAccountsService
    {
        private readonly IUserRepository userRepository;
        private readonly IAccountsMapper accountsMapper;
        public AccountsService(IUserRepository userRepository,
            IAccountsMapper accountsMapper)
        {
            this.userRepository = userRepository;
            this.accountsMapper = accountsMapper;
        }
        public async Task<AccountsDto> GetAccounts(int userId)
        {
            var accountsDto = new AccountsDto();
            var userEntity = await this.userRepository.GetUser(userId);
            if (userEntity == null)
                return accountsDto;
            accountsDto = accountsMapper.Configuration.Map<AccountsDto>(userEntity);

            var groupsDtos = new List<EcwresourcesDto>();
            foreach (var group in userEntity.UsersGroups)
            {
                var groupsRolesEntity = await this.userRepository.GetGroupsRoles((int)group?.GroupsId);
                if (groupsRolesEntity != null)
                {
                    var rolesPermissions = new List<RolesPermissionsDto>();
                    foreach (var groupRole in groupsRolesEntity)
                    {
                        var rolesPermissionsEntity = await this.userRepository.GetRolesPermissions((int)groupRole.RolesId);
                        rolesPermissions.AddRange(accountsMapper.Configuration.Map<IEnumerable<RolesPermissionsDto>>(rolesPermissionsEntity));
                    }
                    accountsDto.RolesPermissions = rolesPermissions;
                }
            }
            return accountsDto;
        }

        public async Task<UsersProfilesDto> GetMember(int memberId)
        {
            var userProfileEntity = await this.userRepository.GetUserProfile(memberId);
            return accountsMapper.Configuration.Map<UsersProfilesDto>(userProfileEntity);
        }

        public async Task<IEnumerable<UsersProfilesDto>> GetMembers(bool isWebUser)
        {
            var userProfileEntity = await this.userRepository.GetUserProfiles(isWebUser);
            return accountsMapper.Configuration.Map<IEnumerable<UsersProfilesDto>>(userProfileEntity);
        }
    }
}
