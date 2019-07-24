using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.Exceptions
{
    public abstract class BaseException : Exception, ISamtelException
    {
        public int ErrorCode { get; set; }
        public string ErrorType { get; set; }
        public bool Success { get; set; }

        protected BaseException(string message, ErrorTypes errorTypes)
            : base(message)
        {
            ErrorCode = (int)errorTypes;
            ErrorType = errorTypes.ToString();
        }

        protected BaseException(string message, ErrorTypes errorTypes, Exception ex)
            : base(message, ex)
        {
            ErrorCode = (int)errorTypes;
            ErrorType = errorTypes.ToString();
        }
    }
}
