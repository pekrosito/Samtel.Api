using Samtel.Application.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Application.ApplicationServices.DTOs;
using Samtel.Application.ApplicationServicesProvider.Assemblers;
using Samtel.Application.BusinessService;

namespace Samtel.Application.ApplicationServicesProvider
{
    public class PersonAplicationService : IPersonAplicationService
    {
        private readonly IPersonRepository _personRepository;
        private readonly RequestContext _requestContext;

        public PersonAplicationService(IPersonRepository exampleTransactionsRepository, RequestContext requestContext)
        {
            _personRepository = exampleTransactionsRepository;
            _requestContext = requestContext;
        }


        public PersonDTO getPersons()
        {
            throw new NotImplementedException();
        }
    }
}
