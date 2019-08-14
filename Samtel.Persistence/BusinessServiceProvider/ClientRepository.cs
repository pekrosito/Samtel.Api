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
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        //private readonly RepositoryBase<Client> _RepositoryBase;

        public ClientRepository(IContext context, RequestContext requestContext)
            : base(context, requestContext)
        {
        }

        //public BigCrediPremium getCredits()
        //{
        //    var testing = Query<BigCrediPremium>("SELECT TOP 1 * FROM BIG_CREDIPREMIUM").FirstOrDefault();
        //    //var testing = Query<EntityExample>("SELECT firstName, lastName, edad, id FROM exampleTables");
        //    return testing;
        //}

        List<Client> IClientRepository.getClients()
        {
            List <Client> clientes = Query<Client>("SELECT TOP 15 * FROM BIG_CLIENTES_TEMP").ToList(); ;
            //var testing = Query<EntityExample>("SELECT firstName, lastName, edad, id FROM exampleTables");
            return clientes;
        }
    }
}
