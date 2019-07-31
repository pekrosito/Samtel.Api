using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Application.ApplicationServices;
using Samtel.Application.BusinessService;
using Samtel.Application.ApplicationServices.DTOs;
using Samtel.Application.ApplicationServicesProvider.Assemblers;

namespace Samtel.Application.ApplicationServicesProvider
{
    public class ClientAplicationService : IClientAplicationService
    {
        private readonly IClientRepository _clientRepository;
        private readonly RequestContext _requestContext;

        public ClientAplicationService(IClientRepository clientTransactionsRepository, RequestContext requestContext)
        {
            _clientRepository = clientTransactionsRepository;
            _requestContext = requestContext;
        }

        public IEnumerable<ClientDTO> getClients()
        {
            return DTOAssembler.CreateClients(_clientRepository.getClients());
        }
    }
}
