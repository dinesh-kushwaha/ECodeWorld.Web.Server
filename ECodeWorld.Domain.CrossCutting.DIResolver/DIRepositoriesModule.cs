using Autofac;
using ECodeWorld.Domain.Infrastructure.Repositories.Authentication;
using ECodeWorld.Domain.Infrastructure.Repositories.Masters;
using ECodeWorld.Domain.Infrastructure.Repositories.Posts;
using ECodeWorld.Domain.Infrastructure.Repositories.User;
using System;

namespace ECodeWorld.Domain.CrossCutting.DIResolver
{
    public class DIRepositoriesModule : Module
    {
        public string connectionString { get; set; }
        public TimeSpan cacheTimespan { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>()
                .WithParameter("connectionString", connectionString)
             .WithParameter("cacheTimespan", cacheTimespan);

            builder.RegisterType<LoginRepository>().As<ILoginRepository>()
                .WithParameter("connectionString", connectionString)
             .WithParameter("cacheTimespan", cacheTimespan);

            builder.RegisterType<PostsRepository>().As<IPostsRepository>()
               .WithParameter("connectionString", connectionString)
            .WithParameter("cacheTimespan", cacheTimespan);

            builder.RegisterType<TempPostsRepository>().As<ITempPostsRepository>()
              .WithParameter("connectionString", connectionString)
           .WithParameter("cacheTimespan", cacheTimespan);

            builder.RegisterType<PostsTypeRepository>().As<IPostsTypeRepository>()
              .WithParameter("connectionString", connectionString)
           .WithParameter("cacheTimespan", cacheTimespan);

            builder.RegisterType<PostStatusRepository>().As<IPostStatusRepository>()
              .WithParameter("connectionString", connectionString)
           .WithParameter("cacheTimespan", cacheTimespan);

            builder.RegisterType<PostsComplexityRepository>().As<IPostsComplexityRepository>()
           .WithParameter("connectionString", connectionString)
        .WithParameter("cacheTimespan", cacheTimespan);

            builder.RegisterType<PostCategoryRepository>().As<IPostCategoryRepository>()
         .WithParameter("connectionString", connectionString)
      .WithParameter("cacheTimespan", cacheTimespan);

            builder.RegisterType<ApproversRepository>().As<IApproversRepository>()
        .WithParameter("connectionString", connectionString)
     .WithParameter("cacheTimespan", cacheTimespan);
        }
    }
}
