using ECodeWorld.Domain.Dtos.Core;
using System.Collections.Generic;

namespace ECodeWorld.Domain.Dtos.Accounts
{
    public class AccountsDto : DtoBase
    {
        public AccountsDto()
        {
            RolesPermissions = new List<RolesPermissionsDto>();
            UsersAddress = new List<UsersAddressDto>();
            UsersCertifications = new List<UsersCertificationsDto>();
            UsersGroups = new List<UsersGroupsDto>();
            UsersPolicies = new List<UsersPoliciesDto>();
            UsersProfiles = new List<UsersProfilesDto>();
            UsersQualifications = new List<UsersQualificationsDto>();
        }
        
        public IEnumerable<RolesPermissionsDto> RolesPermissions { get; set; }
        public IEnumerable<UsersAddressDto> UsersAddress { get; set; }
        public IEnumerable<UsersCertificationsDto> UsersCertifications { get; set; }
        public IEnumerable<UsersGroupsDto> UsersGroups { get; set; }
        public IEnumerable<UsersPoliciesDto> UsersPolicies { get; set; }
        public IEnumerable<UsersProfilesDto> UsersProfiles { get; set; }
        public IEnumerable<UsersQualificationsDto> UsersQualifications { get; set; }

    }
}
