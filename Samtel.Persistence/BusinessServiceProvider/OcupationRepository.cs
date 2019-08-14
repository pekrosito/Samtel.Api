using Dapper;
using Samtel.Application;
using Samtel.Application.BusinessService;
using Samtel.Application.BusinessService.Base;
using Samtel.Domain.Models.Entities;
using Samtel.Persistence.BusinessServiceProvider.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Persistence.BusinessServiceProvider
{
    public class OcupationRepository : RepositoryBase<Ocupations>, IOcupationRepository
    {
       // private readonly RepositoryBase<Ocupations> _RepositoryBase;

        public OcupationRepository(IContext context, RequestContext requestContext) : base(context, requestContext)
        {
        }
        public List<Ocupations> getOcupations()
        {
            List<Ocupations> ocupations = Query<Ocupations>("SELECT id, ocupation FROM ocupations").AsList();
            return ocupations;
        }
    }
}
