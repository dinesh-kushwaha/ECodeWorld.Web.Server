using System;
using Xunit;

namespace ECodeWorld.Domain.Tests.Security
{
    public class ECWHashManagerTest
    {
        private const string password = "myP@5sw0rd";
        private const string newPassword = "password";

        [Fact]
        public void Verify_SaltedHash_With_MD5_When_Correct_Password_Test()
        {
            string passwordHashMD5InDB = ECWHashManager.ComputeHash(password, "MD5", null);
            Assert.True(ECWHashManager.VerifyHash(password, "MD5", passwordHashMD5InDB));
        }

        [Fact]
        public void Verif_ySaltedHash_With_MD5_When_InCorrect_Password_Test()
        {
            string passwordHashMD5InDB = ECWHashManager.ComputeHash(password, "MD5", null);
            Assert.False(ECWHashManager.VerifyHash(newPassword, "MD5", passwordHashMD5InDB));
        }

        [Fact]
        public void Verify_SaltedHash_With_SHA256_When_Correct_Password_Test()
        {
            string passwordHashMD5InDB = ECWHashManager.ComputeHash(password, "SHA256", null);
            Assert.True(ECWHashManager.VerifyHash(password, "SHA256", passwordHashMD5InDB));
        }

        [Fact]
        public void Verif_ySaltedHash_With_SHA256_When_InCorrect_Password_Test()
        {
            string passwordHashMD5InDB = ECWHashManager.ComputeHash(password, "SHA256", null);
            Assert.False(ECWHashManager.VerifyHash(newPassword, "SHA256", passwordHashMD5InDB));
        }

        [Fact]
        public void Verify_SaltedHash_With_SHA384_When_Correct_Password_Test()
        {
            string passwordHashMD5InDB = ECWHashManager.ComputeHash(password, "SHA384", null);
            Assert.True(ECWHashManager.VerifyHash(password, "SHA384", passwordHashMD5InDB));
        }

        [Fact]
        public void Verif_ySaltedHash_With_SHA384_When_InCorrect_Password_Test()
        {
            string passwordHashMD5InDB = ECWHashManager.ComputeHash(password, "SHA384", null);
            Assert.False(ECWHashManager.VerifyHash(newPassword, "SHA384", passwordHashMD5InDB));
        }

        [Fact]
        public void Verify_SaltedHash_With_SHA512_When_Correct_Password_Test()
        {
            string passwordHashMD5InDB = ECWHashManager.ComputeHash(password, "SHA512", null);
            Assert.True(ECWHashManager.VerifyHash(password, "SHA512", passwordHashMD5InDB));
        }

        [Fact]
        public void Verif_ySaltedHash_With_SHA512_When_InCorrect_Password_Test()
        {
            string passwordHashMD5InDB = ECWHashManager.ComputeHash(password, "SHA512", null);
            Assert.False(ECWHashManager.VerifyHash(newPassword, "SHA512", passwordHashMD5InDB));
        }


    }
}
