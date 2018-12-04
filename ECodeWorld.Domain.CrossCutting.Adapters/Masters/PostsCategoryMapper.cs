using AutoMapper;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Masters
{
    public class PostsCategoryMapper : IPostsCategoryMapper
    {
        public IMapper Configuration
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PostsCategoriesDto, PostsCategories>();
                    cfg.CreateMap<PostsCategories, PostsCategoriesDto>();
                }).CreateMapper();
            }
        }
    }
}
