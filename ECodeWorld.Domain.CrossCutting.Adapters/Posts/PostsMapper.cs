using AutoMapper;
using ECodeWorld.Domain.Dtos;
using ECodeWorld.Domain.Dtos.Posts;
using ECodeWorld.Domain.Infrastructure.Repositories;
using M = ECodeWorld.Domain.Entities.Models;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Posts
{
    public class PostsMapper : IPostsMapper
    {
        public IMapper Configuration
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SearchCriteriaDto, SearchCriteria>().ReverseMap();
                    cfg.CreateMap<PostsDto, M.Posts>().
                      ForMember(x => x.Author, opt => opt.Ignore()).
                      ForMember(x => x.Category, opt => opt.Ignore()).
                      ForMember(x => x.ComplexityLevels, opt => opt.Ignore()).
                      ForMember(x => x.PostStatus, opt => opt.Ignore()).
                      ForMember(x => x.PostTypes, opt => opt.Ignore()).
                      ForMember(x => x.PostsMl, opt => opt.Ignore()).
                      ReverseMap();

                   

                }).CreateMapper();
            }
        }
    }
}
