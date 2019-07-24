using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.Exceptions
{
    public class AuthenticationException : BaseException
    {
        public AuthenticationException(string message, ErrorTypes errorTypes) : base(message, errorTypes)
        {
        }
    }
}
