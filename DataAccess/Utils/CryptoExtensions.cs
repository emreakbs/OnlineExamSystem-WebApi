using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DataAccess.Utils
{
  public  class CryptoExtensions
    {
        public static string Md5Encrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
                return (string) null;
            string empty = string.Empty;
            byte[] hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(value));
            StringBuilder stringBuilder = new StringBuilder((int) Math.Round((double) (hash.Length * 3) + (double) hash.Length / 8.0));
            int num = hash.Length - 1;
            for (int startIndex = 0; startIndex <= num; ++startIndex)
                stringBuilder.Append(BitConverter.ToString(hash, startIndex, 1));
            return stringBuilder.ToString().TrimEnd(new char[1]
            {
                ' '
            });
        }
    }
}
