using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Domain.Models.Base;

namespace Samtel.Application.BusinessService.Base
{
    public interface IRepository<T> : IDisposable where T : IEntity
    {
        IDbConnection Conn { get; }
        IContext Context { get; }
    }
}
