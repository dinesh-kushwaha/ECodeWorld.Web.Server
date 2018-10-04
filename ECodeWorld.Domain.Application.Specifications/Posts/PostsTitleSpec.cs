using ECodeWorld.Domain.CrossCutting.Specifications.Core;
using ECodeWorld.Domain.Dtos.Posts;
using System;

namespace ECodeWorld.Domain.Application.Specifications.Posts
{
    public class PostsTitleSpec : ISpecification<PostsDto>
    {
        public ISpecification<PostsDto> And(ISpecification<PostsDto> other)
        {
            throw new NotImplementedException();
        }

        public ISpecification<PostsDto> AndNot(ISpecification<PostsDto> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSatisfiedBy(PostsDto candidate)
        {
            return true;
        }

        public ISpecification<PostsDto> Not()
        {
            throw new NotImplementedException();
        }

        public ISpecification<PostsDto> Or(ISpecification<PostsDto> other)
        {
            throw new NotImplementedException();
        }

        public ISpecification<PostsDto> OrNot(ISpecification<PostsDto> other)
        {
            throw new NotImplementedException();
        }
    }
}
