using ECodeWorld.Domain.CrossCutting.Security;
using Xunit;

namespace ECodeWorld.Domain.Tests.Security
{

    public class ECWRNGRfcSaltedHashManagerTest
    {
        [Fact]
        public void RNGRfc_When_Correct_Password_Test()
        {
            string password = "myP@5sw0rd";
            //string newPassword = "password";
            string hash = "";
            string salt = "";

            ECWRNGRfcSaltedHashManager.GenrateSaltedHash(password, out hash, out salt);
            Assert.True(ECWRNGRfcSaltedHashManager.VerifyPassword(password, hash, salt));
        }

        [Fact]
        public void Verif_ySaltedHash_With_MD5_When_InCorrect_Password_Test()
        {
            string password = "myP@5sw0rd";
            string newPassword = "password";
            string hash = "";
            string salt = "";

            ECWRNGRfcSaltedHashManager.GenrateSaltedHash(password, out hash, out salt);
            Assert.False(ECWRNGRfcSaltedHashManager.VerifyPassword(newPassword, hash, salt));
        }
    }
}
