using AutoMapper;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Masters
{
    public class PostsStatusMapper : IPostsStatusMapper
    {
        public IMapper Configuration
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PostsStatusDto, PostsStatus>();
                    cfg.CreateMap<PostsStatus, PostsStatusDto>();
                }).CreateMapper();
            }
        }
    }
}
