using AutoMapper;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Posts;
using ECodeWorld.Domain.Dtos.Users;
using ECodeWorld.Domain.Entities.Models;
using ECodeWorld.Domain.Infrastructure.Repositories;

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
                    cfg.CreateMap<SearchCriteriaDto, SearchCriteria>().ReverseMap();
                    cfg.CreateMap<AuthorDto, Users>().ReverseMap();
                    cfg.CreateMap<TempPostsDto, TempPosts>().
                    ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author)).
                    ForMember(x => x.Category, opt => opt.Ignore()).
                    ForMember(x => x.ComplexityLevels, opt => opt.Ignore()).
                    ForMember(x => x.PostStatus, opt => opt.Ignore()).
                    ForMember(x => x.PostTypes, opt => opt.Ignore()).
                    ForMember(x => x.TempPostsMl, opt => opt.Ignore()).
                    ReverseMap();
                }).CreateMapper();
            }
        }
    }
}
