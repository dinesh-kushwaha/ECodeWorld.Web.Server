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
                    cfg.CreateMap<AccountsDto, Users>().ReverseMap();
                    cfg.CreateMap<RolesPermissionsDto, RolesPermissions>().ReverseMap();
                    cfg.CreateMap<EcwresourcesDto, Ecwresources>().ReverseMap();
                    cfg.CreateMap<PermissionsDto, Permissions>().ReverseMap();
                }).CreateMapper();
            }
        }
    }
}
