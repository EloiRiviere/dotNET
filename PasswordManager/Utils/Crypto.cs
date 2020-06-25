using System.Text;
using System.Security.Cryptography;

namespace PasswordsManager.Utils
{
    public static class Crypto
    {

        public static string Encrypt(string clear)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(clear));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public static string Decrypt(string encrypted)
        {
            return "";
        }

    }
}
