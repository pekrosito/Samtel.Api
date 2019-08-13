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
    public class OcupationRepository : RepositoryBase<Ocupation>, IOcupationRepository
    {
        private readonly RepositoryBase<Client> _RepositoryBase;

        public OcupationRepository(IContext context, RequestContext requestContext) : base(context, requestContext)
        {
        }

        public List<Ocupation> listOcupations()
        {
            var testing = Query<Ocupation>("SELECT * FROM ocupations ").ToList();
            return testing;
        }
    }
}
