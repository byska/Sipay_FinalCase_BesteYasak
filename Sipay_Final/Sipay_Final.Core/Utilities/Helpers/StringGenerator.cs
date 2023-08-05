using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Final.Core.Utilities.Helpers
{
    public static class StringGenerator
    {
        public static string GenerateRandomPassword(int length = 12)
        {

            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-_=+";
            char[] chars = new char[length];

            using (RNGCryptoServiceProvider cryptoProvider = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[length];

                cryptoProvider.GetBytes(data);

                for (int i = 0; i < length; i++)
                {
                    chars[i] = validChars[data[i] % validChars.Length];
                }
            }
            return new string(chars);

        }
    }
}
