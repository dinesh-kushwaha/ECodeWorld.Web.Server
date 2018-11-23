using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ECodeWorld.Domain.Dtos.Accounts;
using ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Accounts
{
    public class AccountsMapper : IAccountsMapper
    {
        public IMapper Configuration
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AccountsDto, Users>().DisableCtorValidation().ReverseMap();
                    cfg.CreateMap<RolesPermissionsDto, RolesPermissions>().ReverseMap();
                    cfg.CreateMap<EcwresourcesDto, Ecwresources>().ReverseMap();
                    cfg.CreateMap<PermissionsDto, Permissions>().ReverseMap();

                    cfg.CreateMap<CertificationsDto, Certifications>().ReverseMap();
                    cfg.CreateMap<GroupsDto, Groups>().ReverseMap();
                    cfg.CreateMap<QualificationsDto, Qualifications>().ReverseMap();
                    cfg.CreateMap<UniversitiesDto, Universities>().ReverseMap();

                    cfg.CreateMap<UsersAddressDto, UsersAddress>().ReverseMap();
                    cfg.CreateMap<UsersCertificationsDto, UsersCertifications>().ReverseMap();
                    cfg.CreateMap<UsersGroupsDto, UsersGroups>().ReverseMap();
                    cfg.CreateMap<UsersPoliciesDto, UsersPolicies>().ReverseMap();
                    cfg.CreateMap<UsersProfilesDto, UsersProfiles>().DisableCtorValidation().ReverseMap();
                    cfg.CreateMap<UsersQualificationsDto, UsersQualifications>().ReverseMap();

                }).CreateMapper();
            }
        }
    }
}
