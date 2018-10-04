using AutoMapper;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Masters
{
    public class PostCategoryMapper : IPostCategoryMapper
    {
        public IMapper Configuration
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PostCategoriesDto, PostCategories>();
                    cfg.CreateMap<PostCategories, PostCategoriesDto>();
                }).CreateMapper();
            }
        }
    }
}
