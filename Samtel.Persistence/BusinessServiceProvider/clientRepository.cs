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
    public class clientRepository : RepositoryBase<Client>, IClientRepository
     
    {
        private readonly RepositoryBase<Person> _RepositoryBase;

        public clientRepository(IContext context, RequestContext requestContext): base(context, requestContext)
        {
        }

        public List<Client> listClients()
        {
            var testing = Query<Client>("SELECT * FROM BIG_CLIENTES_TEMP ").ToList();
            // _cacheService.Add(keyCache, paymentMethods);
            return testing;
    
        }
    }
}
