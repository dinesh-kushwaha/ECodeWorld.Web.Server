﻿using ECodeWorld.Domain.Application.Services.Authentication;
using ECodeWorld.Domain.Dtos.Authentication;
using ECodeWorld.Domain.Dtos.Users;
using ECodeWorld.Domain.Infrastructure.Repositories.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ECodeWorld.Domain.Tests.Services
{
    public class AuthenticationServiceTest
    {

        [Fact]
        public void Validate()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddXmlFile("app.config")
            //.Add(new LegacyConfigurationProvider())
            .Build();

            //string con = (string)configuration.GetValue(typeof(string), "MyLegacyDb");
            ILoginRepository loginRepository = new LoginRepository();
            IAuthenticationService authenticationService = new AuthenticationService(loginRepository);

            string userName = "2kush.dinesh@gmail.com";
            string password = "P@ssw0rd";

            var resp = authenticationService.VerifyUser(new UserDto { UserName = userName, Password = password });
            var authenticationDto = (AuthenticationDto)resp.Result;
            Assert.True(authenticationDto.IsAuthenticated);
        }

        [Fact]
        public void CreateLogin()
        {
            string userName = "2kush.dinesh@gmail.com";
            string password = "P@ssw0rd";

            ILoginRepository loginRepository = new LoginRepository();
            IAuthenticationService authenticationService = new AuthenticationService(loginRepository);

            var resp = authenticationService.CreateUserLogin(new UserDto { UserName = userName, Password = password });
            //Assert.True(resp.IsAuthenticated);
        }
    }
}
