using AutoMapper;
using ECodeWorld.Domain.Dtos.Posts;
using M = ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Posts
{
    public class TempPostsMapper : ITempPostsMapper
    {
        public IMapper Configuration
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TempPostsDto, M.TempPosts>();
                    cfg.CreateMap<M.TempPosts, TempPostsDto>();
                }).CreateMapper();
            }
        }
    }
}
