using Samtel.Application.BusinessService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Domain.Models.Entities;
using Samtel.Persistence.BusinessServiceProvider.Base;
using Samtel.Application;
using Samtel.Application.BusinessService.Base;

namespace Samtel.Persistence.BusinessServiceProvider
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
         readonly RepositoryBase<Person> _RepositoryBase;

         public PersonRepository(IContext context, RequestContext requestContext)
             : base(context, requestContext)
        {
        }

        public List<Person> getPersons()
        {
            throw new NotImplementedException();
        }
    }
}
