using Autofac;
using ECodeWorld.Domain.CrossCutting.Adapters.Accounts;
using ECodeWorld.Domain.CrossCutting.Adapters.Masters;
using ECodeWorld.Domain.CrossCutting.Adapters.Posts;
using U = ECodeWorld.Domain.CrossCutting.Adapters.Usres;

namespace ECodeWorld.Domain.CrossCutting.DIResolver
{
    public class DIAdaptersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountsMapper>().As<IAccountsMapper>();
            builder.RegisterType<PostsMapper>().As<IPostsMapper>();
            builder.RegisterType<TempPostsMapper>().As<ITempPostsMapper>();
            builder.RegisterType<U.AuthMapper>().As<U.IAuthMapper>();

            builder.RegisterType<PostsTypeMapper>().As<IPostsTypeMapper>();
            builder.RegisterType<PostsStatusMapper>().As<IPostsStatusMapper>();
            builder.RegisterType<PostsComplexityMapper>().As<IPostsComplexityMapper>();
            builder.RegisterType<PostsCategoryMapper>().As<IPostsCategoryMapper>();
            builder.RegisterType<ApproversMapper>().As<IApproversMapper>();
        }
    }
}
