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
    public class IdentificationRepository : RepositoryBase<Ocupation>, IIdentificationRepository
    {
        private readonly RepositoryBase<Client> _RepositoryBase;

        public IdentificationRepository(IContext context, RequestContext requestContext) : base(context, requestContext)
        {
        }

        public List<Identification> listIdentifications()
        {
        
                var testing = Query<Identification>("SELECT * FROM identification ").ToList();
                return testing;
         
        }
    }
}
