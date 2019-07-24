using System;
using System.Linq;

namespace Samtel.Resources.Common.Cryptography
{
    public class UniqueToken
    {
        public static string GenerateToken()
        {
            var i = Guid.NewGuid().ToByteArray().Aggregate<byte, long>(1, (current, b) => current * ((int)b + 1));
            //$
            return "{i - DateTime.Now.Ticks:x}";
        }

        public static string GenerateShortToken(int length)
        {
            var generator = new Random();
            if (length > 9)
                length = 9;
            return generator.Next(0, Convert.ToInt32(Math.Pow(10, length))).ToString("D" + length);
        }
    }
}
