using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Samtel.Domain.Models.Base;

namespace Samtel.Domain.Models
{
    public class User : Entity
    {
        public string user_username { get; set; }
        public string user_password { get; set; }
        public string user_name { get; set; }
        public string user_code { get; set; }
        public DateTime? user_creation_date { get; set; }
        public string user_email { get; set; }
        public string usertype { get; set; }
        public int user_is_active { get; set; }
        public int usertypeId { get; set; }
        public string roleName { get; set; }
        public int roleId { get; set; }


        public void GenerateNewTokenPassword()
        {
            var expireBytes = new ASCIIEncoding().GetBytes(string.Format(CultureInfo.InvariantCulture, "{0}:{1}", Id, DateTime.UtcNow.AddDays(1).ToBinary()));
            //remove '=', so trim them from the end
            //PasswordToken = Convert.ToBase64String(expireBytes).TrimEnd(new[] { '=' });
        }

        public virtual void ResetTokenRecoveryPassword()
        {
            // PasswordToken = null;
            // NeedChangePassword = false;
        }

        public bool CheckPasswordToken(string tokenRecoveryPassword)
        {
            if (string.IsNullOrEmpty(tokenRecoveryPassword)) return false;
            //  if (tokenRecoveryPassword != PasswordToken) return false;
            var PasswordToken = "5958";
            DateTime expireTime;
            var numPadChars = 0 % 4;
            if (numPadChars > 0)
                numPadChars = 4 - numPadChars;
            var newToken = PasswordToken.PadRight(0 + numPadChars, '=');

            try
            {
                var decodedBytes = Convert.FromBase64String(newToken);
                var parts = new ASCIIEncoding().GetString(decodedBytes).Split(':');
                if (parts.Length != 2 || (parts.Length == 2 && parts[0] != Id.ToString())) return false;
                expireTime = DateTime.FromBinary(long.Parse(parts[1]));
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }

            return (DateTime.UtcNow <= expireTime);
        }
    }

    public class LoginResponse
    {
        public Int32 userId { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public Int32 usertypeId { get; set; }
        public string usertype { get; set; }
        public string email { get; set; }
        public string code { get; set; }
        public string Token { get; set; }
    }

    public class updateTokenNotification
    {
        public int user_id { get; set; }
        public string session_device_id { get; set; }
    }
}
