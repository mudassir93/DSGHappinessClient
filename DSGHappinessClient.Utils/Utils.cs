using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace DSGHappinessClient.Utils
{
    public  static class Utils
    {
        public static string GetEncodedString(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("Parameter 'str' cannot have empty or null value. Please enter the valid string.", "str");

            return HttpUtility.UrlEncode(str);
        }

        public static string GetCurrentUtcTimeStamp()
        {
            return DateTime.UtcNow.ToString("dd/MM/yyyyy HH:mm:ss");
        }

        public static string GetJsonString(Dictionary<string, object> dictionary)
        {
            return JsonConvert.SerializeObject(dictionary);
        }

        public static string GetRandomString()
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);
        }

        public static string GetSHA512(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("Parameter 'str' cannot have empty or null value. Please enter the valid string.", "str");

            using SHA512 sha = new SHA512Managed();

            var hashed = sha.ComputeHash(Encoding.UTF8.GetBytes(str));

            // Merge all bytes into a string of bytes  
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashed.Length; i++)
            {
                builder.Append(hashed[i].ToString("x2"));
            }

            string result = builder.ToString();

            return result;
        }
    }
}
