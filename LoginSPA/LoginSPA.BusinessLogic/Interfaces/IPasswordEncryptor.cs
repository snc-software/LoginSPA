using System.Security;

namespace LoginSPA.BusinessLogic.Interfaces
{
    public interface IPasswordEncryptor
    {
        string Encrypt(SecureString password, string salt);
        string GenerateSalt();
    }
}