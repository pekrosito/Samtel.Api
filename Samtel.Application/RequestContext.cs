using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Domain.Models;

namespace Samtel.Application
{
    public class RequestContext
    {
        public Session CurrentSession { get; set; }
        public SystemType System { get; set; }
    }
}
