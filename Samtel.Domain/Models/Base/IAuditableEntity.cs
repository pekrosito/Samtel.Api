using System;

namespace Samtel.Domain.Models.Base
{
    public interface IAuditableEntity : IEntity
    {
        DateTime CreatedDate { get; set; }
        Int32? CreatedById { get; set; }
        DateTime UpdatedDate { get; set; }
        Int32? UpdatedById { get; set; }
    }
}
