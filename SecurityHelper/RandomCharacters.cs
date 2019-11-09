using System;

namespace SecurityHelper
{
    public static class RandomCharacters
    {
        public static string Random(int length = 8)
        {
            var allowedChars = "abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ123456789#@%_.";

            var chars = new char[length];
            var rd = new Random();

            for (int i = 0; i < length; i++)
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];

            return new string(chars);
        }
    }
}
