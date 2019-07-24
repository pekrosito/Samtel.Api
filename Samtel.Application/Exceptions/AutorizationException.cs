using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.Exceptions
{
    public class AutorizationException : BaseException
    {
        public AutorizationException(string message, ErrorTypes errorTypes) : base(message, errorTypes)
        {
        }
    }
}
