using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.BusinessService.Base
{
    public interface IContext : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction CurrentTransaction { get; set; }
    }
}
