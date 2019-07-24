using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Samtel.Infraestructure.Common.Cryptography
{
    public class CryptographyEncode
    {
        public static string EncodeSha256(string stringToEncode)
        {
            if (string.IsNullOrEmpty(stringToEncode)) throw new ArgumentNullException(stringToEncode);
            Encoding encoding = new ASCIIEncoding();
            var message = encoding.GetBytes(stringToEncode);

            var hashString = new SHA256Managed();

            var hashValue = hashString.ComputeHash(message);
            return "a";//hashValue.Aggregate("", (current, x) => current + $"{x:x2}");
        }

        public static string EncodeMd5(string stringToEncode)
        {
            Encoding enc = new ASCIIEncoding();
            MD5 md5 = new MD5CryptoServiceProvider();
            var hashValue = md5.ComputeHash(enc.GetBytes(stringToEncode));
            var encoded = "";
            //$
            for (var i = 0; i < 16; i++)
                encoded += "{hashValue[i]:x02}";
            return encoded;
        }
    }
}
