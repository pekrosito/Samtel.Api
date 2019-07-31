using Samtel.Application.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Application.ApplicationServices.DTOs;
using Samtel.Application.BusinessService;
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

        public List<ClientDTO> listClients()
        {
            return DTOAssembler.listClients(_clientRepository.listClients());
        }
    }
}
