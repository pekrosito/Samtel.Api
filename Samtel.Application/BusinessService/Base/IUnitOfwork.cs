using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.BusinessService.Base
{
    public interface IUnitOfwork : IDisposable
    {
        IContext Context { get; }
        IDbTransaction Transaction { get; }
        IDbTransaction BeginTransaction();
        void Commit();
        bool ExistsTransaction();
        void Rollback();
    }
}
