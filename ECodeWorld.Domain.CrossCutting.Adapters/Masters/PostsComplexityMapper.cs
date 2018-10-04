using AutoMapper;
using ECodeWorld.Domain.Dtos.Masters;
using ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Masters
{
    public class PostsComplexityMapper: IPostsComplexityMapper
    {
        public IMapper Configuration
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ComplexityLevelsDto, ComplexityLevels>();
                    cfg.CreateMap<ComplexityLevels, ComplexityLevelsDto>();
                }).CreateMapper();
            }
        }
    }
}
