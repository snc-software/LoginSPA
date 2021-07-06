using System.Security;
using FluentAssertions;
using LogicSPA.BusinessLogic.Tests.BaseClasses;
using LoginSPA.BusinessLogic;
using LoginSPA.BusinessLogic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicSPA.BusinessLogic.Tests
{
    [TestClass]
    public class PasswordEncryptorTests : PasswordTestBase
    {
        readonly IPasswordEncryptor _passwordEncryptor = new PasswordEncryptor();

        [TestMethod]
        public void ASaltCanSuccessfullyBeGenerated()
        {
            var salt = _passwordEncryptor.GenerateSalt();

            salt.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void TheGeneratedSaltValuesAreUnique()
        {
            var salt1 = _passwordEncryptor.GenerateSalt();
            var salt2 = _passwordEncryptor.GenerateSalt();

            salt1.Should().NotBe(salt2);
        }

        [TestMethod]
        public void TheGeneratedSaltValueHasTheExpectedStringLength()
        {
            var salt = _passwordEncryptor.GenerateSalt();

            salt.Length.Should().Be(32);
        }

        [TestMethod]
        public void APasswordCanSuccessfullyBeHashedUsingASalt()
        {
            var salt = _passwordEncryptor.GenerateSalt();
            var hashedPassword = _passwordEncryptor.Encrypt(ConvertStringToSecureString("SecretPassword1234!"), salt);

            hashedPassword.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void TheGeneratedPasswordHashHasTheExpectedStringLength()
        {
            var salt = _passwordEncryptor.GenerateSalt();
            var hashedPassword = _passwordEncryptor.Encrypt(ConvertStringToSecureString("SecretPassword1234!"), salt);

            Assert.AreEqual(88, hashedPassword.Length);
        }

        [TestMethod]
        public void TheGeneratedPasswordHashIsTheSameValueWhenEncryptingTheSamePasswordWithTheSameSalt()
        {
            var password = ConvertStringToSecureString("SecretPassword1234!");
            var salt = _passwordEncryptor.GenerateSalt();
            var hashedPasswordOne = _passwordEncryptor.Encrypt(password, salt);
            var hashedPasswordTwo = _passwordEncryptor.Encrypt(password, salt);

            hashedPasswordOne.Should().Be(hashedPasswordTwo);
        }

        [TestMethod]
        public void TheGeneratedPasswordHashIsDifferentWhenEncryptinggDifferentPasswordsWithTheSameSalt()
        {
            var salt = _passwordEncryptor.GenerateSalt();
            var hashedPasswordOne = _passwordEncryptor.Encrypt(ConvertStringToSecureString("SecretPassword1234!"), salt);
            var hashedPasswordTwo = _passwordEncryptor.Encrypt(ConvertStringToSecureString("SecretPassword2345!"), salt);

            hashedPasswordOne.Should().NotBe(hashedPasswordTwo);
        }

        [TestMethod]
        public void TheGeneratedPasswordHashIsDifferentWhenEncryptingTheSamePasswordWithDifferentSalts()
        {
            SecureString password = ConvertStringToSecureString("SecretPassword1234!");
            var hashedPasswordOne = _passwordEncryptor.Encrypt(password, _passwordEncryptor.GenerateSalt());
            var hashedPasswordTwo = _passwordEncryptor.Encrypt(password, _passwordEncryptor.GenerateSalt());

            hashedPasswordOne.Should().NotBe(hashedPasswordTwo);
        }
    }
}