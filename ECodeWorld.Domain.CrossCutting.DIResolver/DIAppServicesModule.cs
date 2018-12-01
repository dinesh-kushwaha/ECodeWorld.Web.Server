using Autofac;
using ECodeWorld.Domain.Application.Services.Accounts;
using ECodeWorld.Domain.Application.Services.Authentication;
using ECodeWorld.Domain.Application.Services.Masters;
using ECodeWorld.Domain.Application.Services.Posts;
using ECodeWorld.Domain.Application.Services.User;

namespace ECodeWorld.Domain.CrossCutting.DIResolver
{
    public class DIAppServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AccountsService>().As<IAccountsService>();
            builder.RegisterType<PostsService>().As<IPostsService>();
            builder.RegisterType<TempPostsService>().As<ITempPostsService>();

            builder.RegisterType<PostCategoryService>().As<IPostCategoryService>();
            builder.RegisterType<PostsComplexityService>().As<IPostsComplexityService>();
            builder.RegisterType<PostsStatusService>().As<IPostsStatusService>();
            builder.RegisterType<PostsTypeService>().As<IPostsTypeService>();
            builder.RegisterType<ApproversService>().As<IApproversService>();
        }
       
    }
}
