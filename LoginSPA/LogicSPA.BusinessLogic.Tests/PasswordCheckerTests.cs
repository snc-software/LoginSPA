using FluentAssertions;
using LogicSPA.BusinessLogic.Tests.BaseClasses;
using LoginSPA.BusinessLogic;
using LoginSPA.BusinessLogic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicSPA.BusinessLogic.Tests
{
    [TestClass]
    public class PasswordCheckerTests : PasswordTestBase
    {
        readonly IPasswordEncryptor _passwordEncryptor = new PasswordEncryptor();
        readonly IPasswordChecker _passwordChecker;
        
        public PasswordCheckerTests()
        {
            _passwordChecker = new PasswordChecker(_passwordEncryptor);
        }

        [TestMethod]
        public void ThePasswordsMatchWhenThePasswordIsCorrect()
        {
            var salt = _passwordEncryptor.GenerateSalt();
            var password = ConvertStringToSecureString("SecretPassword1234!");
            var hashedPassword = _passwordEncryptor.Encrypt(password, salt);

            var passwordsMatch = _passwordChecker.PasswordsMatch(password, salt, hashedPassword);

            passwordsMatch.Should().BeTrue();
        }

        [TestMethod]
        public void ThePasswordsDoNotMatchWhenThePasswordIsIncorrect()
        {
            var password = ConvertStringToSecureString("SecretPassword2345");
            var salt = _passwordEncryptor.GenerateSalt();
            var hashedPassword = _passwordEncryptor.Encrypt(ConvertStringToSecureString("SecretPassword1234!"), salt);

            var passwordsMatch = _passwordChecker.PasswordsMatch(password, salt, hashedPassword);

            passwordsMatch.Should().BeFalse();
        }
    }
}