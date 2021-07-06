using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using LoginSPA.BusinessLogic.Interfaces;

namespace LoginSPA.BusinessLogic
{
    public class PasswordEncryptor : IPasswordEncryptor
    {
        public string Encrypt(SecureString password, string salt)
        {
            string combined = ConvertToUnsecureString(password) + salt;
            return HashString(combined);
        }

        public string GenerateSalt()
        {
            return Guid.NewGuid().ToString("N");
        }

        #region Private Functionality

        static string HashString(string toHash)
        {
            using (SHA512CryptoServiceProvider sha = new SHA512CryptoServiceProvider())
            {
                byte[] dataToHash = Encoding.UTF8.GetBytes(toHash);
                byte[] hashed = sha.ComputeHash(dataToHash);
                return Convert.ToBase64String(hashed);
            }
        }

        static string ConvertToUnsecureString(SecureString securePassword)
        {
            var unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        #endregion
    }
}