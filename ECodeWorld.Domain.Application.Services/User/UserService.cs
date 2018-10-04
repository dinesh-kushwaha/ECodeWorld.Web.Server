using ECodeWorld.Domain.Application.Specifications.User;
using ECodeWorld.Domain.CrossCutting.Adapters.Usres;
using ECodeWorld.Domain.CrossCutting.Security;
using ECodeWorld.Domain.Dtos.Authentication;
using ECodeWorld.Domain.Dtos.Message;
using ECodeWorld.Domain.Dtos.Users;
using ECodeWorld.Domain.Entities.Models;
using ECodeWorld.Domain.Infrastructure.Repositories.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECodeWorld.Domain.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IAuthMapper authMapper;
        public UserService(IUserRepository userRepository, IAuthMapper authMapper)
        {
            this.userRepository = userRepository;
            this.authMapper = authMapper;
        }

        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            var authenticationDto = new AuthenticationDto();
            var userSpecification = new UserSpecification().
                And(new UserNameSpecification()).
                And(new PasswordSpecification()).
                And(new UniqueUserSpecification(this.userRepository));

            if (userSpecification.IsSatisfiedBy(userDto))
            {
                string passwordSalt = "";
                string passwordHash = "";
                ECWRNGRfcSaltedHashManager.GenrateSaltedHash(userDto.Password, out passwordHash, out passwordSalt);
                var newUser = new Logins
                {
                    UserName = userDto.UserName,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash
                };
                int identity = await this.userRepository.CreateLogin(newUser);
                if (identity <= 0)
                {
                    userDto.AddRule("User", "Creation faild!");
                }
                else
                {
                    userDto.AddRule("Success", "Authentication is successfull.");
                }
            }
            return userDto;
        }

        public async Task<Users> GetUserByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return null;
            else
                return await this.userRepository.GetUserByUserName(userName);
        }

        public async Task<UserProfileDto> GetUserProfile(string userName)
        {
            var userProfile = await this.userRepository.GetUserProfile(userName);
            return this.authMapper.Configuration.Map<UserProfileDto>(userProfile);
        }

        public Task<UserProfileDto> GetUserProfileById(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserProfileDto>> GetUserProfiles(int profileType = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> UpdateUserProfile(UserProfileDto userProfileDto)
        {
            var user = await this.GetUserByUserName(userProfileDto.UserName);
            var userProfile = this.authMapper.Configuration.Map<UserProfiles>(userProfileDto);
            userProfile.UsersId = user.Id;
            var userId = await this.userRepository.UpdateUserProfile(userProfile);
            return new ResponseDto { Id = userId };
        }
    }
}
