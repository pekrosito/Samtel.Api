using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.Exceptions
{
    public class TransactionException : BaseException
    {
        public TransactionException(string message, ErrorTypes errorTypes) : base(message, errorTypes)
        {
        }
    }
}
