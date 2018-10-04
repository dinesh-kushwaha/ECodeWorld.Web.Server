using AutoMapper;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Masters
{
    public class PostStatusMapper : IPostStatusMapper
    {
        public IMapper Configuration
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PostStatusDto, PostStatus>();
                    cfg.CreateMap<PostStatus, PostStatusDto>();
                }).CreateMapper();
            }
        }
    }
}
