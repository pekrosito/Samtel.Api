using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.Exceptions
{
    public enum ErrorTypes
    {
        MissingParameter = 1000,

        SessionDontExists = 1014,

        SystemParameterNotConfigured = 100000,
    }
}
