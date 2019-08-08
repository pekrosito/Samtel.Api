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
    public class CreditRepository : RepositoryBase<BigCrediPremium>, ICreditRepository
    {
        readonly RepositoryBase<BigCrediPremium> _RepositoryBase;

        public CreditRepository(IContext context, RequestContext requestContext)
            : base(context, requestContext)
        {
        }

        //public BigCrediPremium getCredits()
        //{
        //    var testing = Query<BigCrediPremium>("SELECT TOP 1 * FROM BIG_CREDIPREMIUM").FirstOrDefault();
        //    //var testing = Query<EntityExample>("SELECT firstName, lastName, edad, id FROM exampleTables");
        //    return testing;
        //}

        List<BigCrediPremium> ICreditRepository.getCredits()
        {
            var testing = Query<BigCrediPremium>("SELECT * FROM BIG_CREDIPREMIUM").ToList(); ;
            //var testing = Query<EntityExample>("SELECT firstName, lastName, edad, id FROM exampleTables");
            return testing;
        }
    }


}
