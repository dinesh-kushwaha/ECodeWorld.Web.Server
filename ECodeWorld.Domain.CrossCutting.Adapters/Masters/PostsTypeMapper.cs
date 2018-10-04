using AutoMapper;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Masters
{
    public class PostsTypeMapper: IPostsTypeMapper
    {
        public IMapper Configuration
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PostTypesDto, PostTypes>();
                    cfg.CreateMap<PostTypes, PostTypesDto>();
                }).CreateMapper();
            }
        }
    }
}
