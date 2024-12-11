using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;

namespace LogicLayer
{
    public class HelpTools
    {
        public static string EncryptSHA256(string source)
        {
            string result = "";
            byte[] data;
            using (SHA256 sha256hash = SHA256.Create())
            {
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            var stringPassword = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                stringPassword.Append(data[i].ToString("x2"));
            }
            result = stringPassword.ToString();

            return result;
        }
        public static string DecryptSHA256(string hashToDecrypt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                for (int i = 0; i < 1000000; i++) // Brute force example, iterate through possible inputs
                {
                    string input = i.ToString();
                    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                    byte[] hashBytes = sha256.ComputeHash(inputBytes);
                    string computedHash = BitConverter.ToString(hashBytes).Replace("-", "");

                    if (computedHash.Equals(hashToDecrypt, StringComparison.OrdinalIgnoreCase))
                    {
                        return input;
                    }
                }
            }

            return string.Empty; // Hash not found
        }

    }
}
