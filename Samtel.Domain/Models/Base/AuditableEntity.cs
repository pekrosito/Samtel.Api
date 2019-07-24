using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Domain.Models.Base
{
    public abstract class AuditableEntity : Entity, IAuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public Int32? CreatedById { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32? UpdatedById { get; set; }
    }
}
