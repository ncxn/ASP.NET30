﻿using System.Text;
using System.Security.Cryptography;

namespace SecurityHelper
{
    public static class Encryptor
    {
        public static string Md5(string input)
        {
            using MD5 md5Hash = new MD5CryptoServiceProvider();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i <= data.Length - 1; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }
    }
}
