using Samtel.Application.BusinessService;
using Samtel.Persistence.BusinessServiceProvider.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Domain.Models.Entities;
using Samtel.Application.BusinessService.Base;
using Samtel.Application;

namespace Samtel.Persistence.BusinessServiceProvider
{
    public class IdentificationRepository : RepositoryBase<Identification>, IIdentificationRepository
    {
        private readonly RepositoryBase<Identification> _RepositoryBase;

        public IdentificationRepository(IContext context, RequestContext requestContext)
            : base(context, requestContext)
        {
        }
        public IEnumerable<Identification> getIdentifications()
        {
            IEnumerable<Identification> listIdentifications = new List<Identification>();

            listIdentifications = Query<Identification>("SELECT id, identification FROM identification").ToList();

            return listIdentifications;
        }
    }
}

