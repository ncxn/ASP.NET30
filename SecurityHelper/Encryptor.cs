using System;
using System.Security.Cryptography;
using System.Text;

namespace SecurityHelper
{
    public class Encryptor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0067:Dispose objects before losing scope", Justification = "<Pending>")]
        public static string Md5(string input)
        {
            MD5 md5Hash = new MD5CryptoServiceProvider();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i <= data.Length - 1; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }

        public static string RandomPassWord(int length = 8)
        {
            var allowedChars = "abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ123456789#@%_.";

            var chars = new char[length - 1 + 1];
            var rd = new Random();

            for (var i = 0; i <= length - 1; i++)
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];

            return new string(chars);
        }
    }
}
