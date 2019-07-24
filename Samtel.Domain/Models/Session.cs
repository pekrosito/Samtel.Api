using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Domain.Models
{
    public class Session
    {
        public Int32 UserId { get; set; }
        public String token { get; set; }

        public string session_token { get; set; }
        public string session_device_id { get; set; }
        public string session_device_notification_id { get; set; }
        public DateTime? session_start_datetime { get; set; }
        public DateTime? session_end_datetime { get; set; }
    }
}
