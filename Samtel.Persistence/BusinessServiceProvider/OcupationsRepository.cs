using Samtel.Persistence.BusinessServiceProvider.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Domain.Models.Entities;
using Samtel.Application.BusinessService;
using Samtel.Application.BusinessService.Base;
using Samtel.Application;

namespace Samtel.Persistence.BusinessServiceProvider
{
    public class OcupationsRepository : RepositoryBase<Ocupations>, IOcupationsRepository
    {
        private readonly RepositoryBase<Ocupations> _RepositoryBase;

        public OcupationsRepository(IContext context, RequestContext requestContext)
            : base(context, requestContext)
        {
        }    
        public IEnumerable<Ocupations> getOcupations()
        {
            IEnumerable<Ocupations> listOcupations = new List<Ocupations>();

            listOcupations = Query<Ocupations>("SELECT id, ocupation FROM ocupations").ToList();

            return listOcupations;
        }
    }
}
