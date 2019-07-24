using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Domain.Models.Base
{
    public interface IEntity
    {
        Int32 Id { get; set; }
    }
}
