using AutoMapper;
using ECodeWorld.Domain.Dtos.Users;
using ECodeWorld.Domain.Entities.Models;


namespace ECodeWorld.Domain.CrossCutting.Adapters.Usres
{
    public class AuthMapper: IAuthMapper
    {
        public IMapper Configuration
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserProfileDto, UsersProfiles>();
                    cfg.CreateMap<UsersProfiles, UserProfileDto>();
                }).CreateMapper();
            }
        }
    }
}
