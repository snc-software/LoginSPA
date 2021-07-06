using System.Security;
using LoginSPA.BusinessLogic.Interfaces;

namespace LoginSPA.BusinessLogic
{
    public class PasswordChecker : IPasswordChecker
    {
        readonly IPasswordEncryptor _passwordEncryptor;
        public PasswordChecker(IPasswordEncryptor passwordEncryptor)
        {
            _passwordEncryptor = passwordEncryptor;
        }
        
        public bool PasswordsMatch(SecureString passwordToCheck, string salt, string hashedPassword)
        {
            var encryptedPassword = EncryptPassword(passwordToCheck, salt);
            return hashedPassword == encryptedPassword;
        }

        #region Private Functionality

        string EncryptPassword(SecureString password, string salt)
        {
            return _passwordEncryptor.Encrypt(password, salt);
        }

        #endregion
    }
}