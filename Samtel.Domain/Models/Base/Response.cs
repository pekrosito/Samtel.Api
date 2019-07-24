using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Domain.Models.Base
{
    public class Response
    {
        public String Message { get; set; }
        public Boolean Success { get; set; }
        public Int32 result { get; set; }
    }
}
