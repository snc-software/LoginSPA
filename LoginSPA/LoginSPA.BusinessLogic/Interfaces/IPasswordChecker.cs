using System.Security;

namespace LoginSPA.BusinessLogic.Interfaces
{
    public interface IPasswordChecker
    {
        bool PasswordsMatch(SecureString passwordToCheck, string salt, string hashedPassword);
    }
}