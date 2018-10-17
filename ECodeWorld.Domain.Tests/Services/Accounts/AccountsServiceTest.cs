using Autofac;
using ECodeWorld.Domain.Application.Services.Accounts;
using ECodeWorld.Domain.Application.Services.Authentication;
using ECodeWorld.Domain.Dtos.Users;
using ECodeWorld.Domain.Infrastructure.Repositories.Authentication;
using ECodeWorld.Domain.Infrastructure.Repositories.User;
using Xunit;


namespace ECodeWorld.Domain.Tests.Services.Accounts
{
    public class AccountsServiceTest : ECWTestsBase
    {
        public IAccountsService IAccountsService { get; private set; }

        [Fact]
        public async void GetAccountsTest()
        {
            IAccountsService accountsService = this.AutofacContainer.Resolve<IAccountsService>();
            //string userName = "dinesh.kushwaha@ecw.com";
            string userName = "jyoti.kushwah@ecw.com";
            var accountPermissions = await accountsService.GetAccounts(userName);
            Assert.True(accountPermissions != null);
        }

        [Fact]
        public void CreateLogin()
        {
            string userName = "2kush.dinesh@gmail.com";
            string password = "P@ssw0rd";

            ILoginRepository loginRepository = new LoginRepository();
            IUserRepository userRepository = new UserRepository();
            IAuthenticationService authenticationService = new AuthenticationService(loginRepository, userRepository);

            var resp = authenticationService.CreateUserLogin(new UserDto { UserName = userName, Password = password });
            //Assert.True(resp.IsAuthenticated);
        }
    }
}
