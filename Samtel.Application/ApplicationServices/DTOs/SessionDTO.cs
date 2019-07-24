using Samtel.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServices.DTOs
{
    public class SessionDTO
    {
        public int user_id { get; set; }
        public string session_token { get; set; }
        public string session_device_id { get; set; }
        public string session_device_notification_id { get; set; }
        public DateTime session_start_datetime { get; set; }
        public DateTime session_end_datetime { get; set; }
        public string user_username { get; set; }
        public string user_email { get; set; }
        public string user_code { get; set; }
        public string user_name { get; set; }
        public string usertype { get; set; }
        public Int32 usertype_id { get; set; }
    }
}
