using System.Security;

namespace LogicSPA.BusinessLogic.Tests.BaseClasses
{
    public abstract class PasswordTestBase
    {
        protected SecureString ConvertStringToSecureString(string unsecureString)
        {
            var secureString = new SecureString();

            foreach (var c in unsecureString)
            {
                secureString.AppendChar(c);
            }

            return secureString;
        }
    }
}