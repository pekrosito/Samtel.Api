using Samtel.Application.BusinessService.Base;
using System;
using System.Collections.Generic;
using Samtel.Domain.Models.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.BusinessService
{
    public interface IOcupationsRepository : IRepository<Ocupations>
    {
        IEnumerable<Ocupations> getOcupations();
    }
}
