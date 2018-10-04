using AutoMapper;

namespace ECodeWorld.Domain.CrossCutting.Adapters.Masters
{
    public interface IPostCategoryMapper
    {
        IMapper Configuration { get; }
    }
}
