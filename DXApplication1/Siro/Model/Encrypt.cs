using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Model
{
    public static class Encrypt
    {
        public static string Crypt(this string text)
        {
            string result = null;

            if (!String.IsNullOrEmpty(text))
            {
                byte[] plaintextBytes = Encoding.Unicode.GetBytes(text);

                SymmetricAlgorithm symmetricAlgorithm = DES.Create();
                symmetricAlgorithm.Key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plaintextBytes, 0, plaintextBytes.Length);
                    }

                    result = Encoding.Unicode.GetString(memoryStream.ToArray());
                }
            }

            return result;
        }

        public static string Decrypt(this string text)
        {
            string result = null;

            if (!String.IsNullOrEmpty(text))
            {
                byte[] encryptedBytes = Encoding.Unicode.GetBytes(text);

                SymmetricAlgorithm symmetricAlgorithm = DES.Create();
                symmetricAlgorithm.Key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                using (MemoryStream memoryStream = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] decryptedBytes = new byte[encryptedBytes.Length];
                        cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                        result = Encoding.Unicode.GetString(decryptedBytes);
                    }
                }
            }

            return result;
        }
    }
}
