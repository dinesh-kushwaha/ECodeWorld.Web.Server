using ECodeWorld.Domain.Application.Services.Core;
using ECodeWorld.Domain.Application.Specifications.User;
using ECodeWorld.Domain.CrossCutting.Security;
using ECodeWorld.Domain.CrossCutting.Specifications.Core;
using ECodeWorld.Domain.Dtos.Authentication;
using ECodeWorld.Domain.Dtos.Message;
using ECodeWorld.Domain.Dtos.Users;
using ECodeWorld.Domain.Entities.Models;
using ECodeWorld.Domain.Infrastructure.Repositories.Authentication;
using ECodeWorld.Domain.Infrastructure.Repositories.User;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.Authentication
{
    public class AuthenticationService : ServiceBase, IAuthenticationService
    {
        private readonly ILoginRepository loginRepository;
        private readonly IUserRepository userRepository;
        public AuthenticationService(ILoginRepository loginRepository,
            IUserRepository userRepository)
        {
            this.loginRepository = loginRepository;
            this.userRepository = userRepository;
        }

        public async Task<ResponseDto> CreateUserLogin(UserDto userDto)
        {
            var authenticationDto = new AuthenticationDto();
            ISpecification<UserDto> specification = new UserNameSpecification()
                .And(new PasswordSpecification());

            if (specification.IsSatisfiedBy(userDto))
            {
                var user = new Users();
                user.UserName = userDto.UserName;


                string passwordHash = ""; string passwordSalt = "";
                ECWRNGRfcSaltedHashManager.GenrateSaltedHash(userDto.Password, out passwordHash, out passwordSalt);

                user.Logins.Add(new Logins { UserName = userDto.UserName, PasswordHash = passwordHash, PasswordSalt = passwordSalt });
                var userId = await this.loginRepository.CreateLogin(user);
                if (userId <= 0)
                    authenticationDto.AddRule("userDto", "Server Error.");
            }

            return authenticationDto;
        }

        public async Task<AuthenticationDto> VerifyUser(UserDto userDto)
        {
            var authenticationDto = new AuthenticationDto();
            ISpecification<UserDto> specification = new UserNameSpecification();

            if (!specification.IsSatisfiedBy(userDto))
                authenticationDto.AddRule("userDto", "UserName is empty.");

            var userLogin = await this.loginRepository.GetLogin(userDto.UserName);
            if (userLogin == null)
            {
                authenticationDto.AddRule("userDto", "Invalid UserName.");
                return authenticationDto;
            }

            if (!ECWRNGRfcSaltedHashManager.VerifyPassword(userDto.Password, userLogin.PasswordHash, userLogin.PasswordSalt))
                authenticationDto.AddRule("userDto", "UserName or password is incorrect.");
            else
            {
                authenticationDto.IsAuthenticated = true;
                var user = await this.userRepository.GetUserByUserName(userDto.UserName);
                if (user != null)
                {
                    authenticationDto.Id = user.Id;
                    authenticationDto.Name = user.DisplayName;
                }
                authenticationDto.AddRule("Success", "Authentication is successfull.");
            }
            return authenticationDto;
        }
    }
}
