using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Application.BusinessService.Base;
using Samtel.Domain.Models.Entities;

namespace Samtel.Application.BusinessService
{
    public interface IIdentificationRepository : IRepository<Identification>
    {
        IEnumerable<Identification> getIdentifications();
    }
}