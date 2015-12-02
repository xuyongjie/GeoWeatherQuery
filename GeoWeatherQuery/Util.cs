using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GeoWeatherQuery
{
    public static class Util
    {

        public static string ToAppSetting(this string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }


        public static string HashHMAC(string PublicKey, string PrivateKey)
        {
            var enc = Encoding.UTF8;
            HMACSHA1 hmac = new HMACSHA1(enc.GetBytes(PrivateKey));
            hmac.Initialize();
            byte[] buffer = enc.GetBytes(PublicKey);

            return Convert.ToBase64String(hmac.ComputeHash(buffer));
        }

        public static string UrlEncode(string s)
        {
            return HttpUtility.UrlEncode(s);
        }
    }
}
