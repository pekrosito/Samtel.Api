using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message, ErrorTypes errorTypes) : base(message, errorTypes)
        {
        }

        public NotFoundException(string message, ErrorTypes errorTypes, Exception ex) : base(message, errorTypes, ex)
        {
        }
    }
}
