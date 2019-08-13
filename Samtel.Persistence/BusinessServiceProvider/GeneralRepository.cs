using Samtel.Application;
using Samtel.Application.BusinessService;
using Samtel.Application.BusinessService.Base;
using Samtel.Domain.Models.Base;
using Samtel.Domain.Models.Entities;
using Samtel.Persistence.BusinessServiceProvider.Base;
using System;
using System.Collections.Generic;
using Dapper;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Persistence.BusinessServiceProvider
{
    public class GeneralRepository : RepositoryBase<Entity>, IGeneralRepository
    {
        private readonly RepositoryBase<Entity> _RepositoryBase;

        public GeneralRepository(IContext context, RequestContext requestContext)
            : base(context, requestContext)
        {
        }

        public List<General> getOcupations()
        {
            return Query<General>("SELECT id, ocupation as Description FROM ocupations").AsList();
        }

        public List<General> getIdentifications()
        {
            return Query<General>("SELECT id, identification as Description FROM identification").AsList();
        }
    }
}
