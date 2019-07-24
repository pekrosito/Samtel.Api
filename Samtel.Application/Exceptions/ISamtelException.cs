using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.Exceptions
{
    public interface ISamtelException
    {
        int ErrorCode { get; set; }
        string ErrorType { get; set; }
        bool Success { get; set; }
    }
}
