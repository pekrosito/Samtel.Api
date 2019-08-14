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
    public class GeneralRepository : RepositoryBase<Identification>, IGeneralRepository
    {
        //private readonly RepositoryBase<identification> _RepositoryBase;

        public GeneralRepository(IContext context, RequestContext requestContext)
            : base(context, requestContext)
        {
        }

        public List<Identification> getIdentification()
        {
            

            List<Identification> identifications = Query<Identification>("SELECT id, identification FROM identification").ToList();

            
            return identifications;
        }
         public List<Ocupations> getOcupations()
        {
            List<Ocupations> ocupations = Query<Ocupations>("SELECT id, ocupation FROM ocupations").ToList();
            return ocupations;
        }
    }
}
