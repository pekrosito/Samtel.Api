using Samtel.Domain.Models.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.BusinessService
{
    public interface IParameterRepository
    {
        string GetValue(string parameterName);
        void SaveOrUpdate(Parameter parameter);
    }
}
