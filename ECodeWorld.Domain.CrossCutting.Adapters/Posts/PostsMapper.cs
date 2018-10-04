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
                    cfg.CreateMap<SearchCriteriaDto, SearchCriteria>();
                    cfg.CreateMap<SearchCriteria, SearchCriteriaDto>();

                    cfg.CreateMap<PostsDto, M.Posts>();
                    cfg.CreateMap<M.Posts, PostsDto>();
                }).CreateMapper();
            }
        }
    }
}
