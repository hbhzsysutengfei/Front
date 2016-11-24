using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace Front.Util
{
    public class EncryptDecryptHelper
    {
        private static readonly int BufSetSize = 62;
        private static readonly char[] bufSet = {'0','1','2','3','4','5','6','7','8','9',  
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};

        public static string getSalt()
        {
            return Convert.ToBase64String( Guid.NewGuid().ToByteArray());
        }

        public static string encryptString(String str)
        {
            if (str != null && str.Length != 0)
            {
                byte[] data = System.Text.Encoding.Unicode.GetBytes(str);
                return Convert.ToBase64String( MD5CryptoServiceProvider.Create().ComputeHash(data));
            }
            return null;
        }

        public static string  encryptString(String password, string salt)
        {
            return encryptString(password + salt);
        }


        public static string getRandomString(int length=8)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(bufSet[random.Next(BufSetSize)]);
            }
            return sb.ToString();
        }

        
    }
}