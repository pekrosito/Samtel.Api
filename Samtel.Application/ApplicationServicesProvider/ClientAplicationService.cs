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

        public bool createClient(ClientDTO client)
        {
            return _clientRepository.createClient(ModelAssembler.CreateClient(client));
        }

        public List<ClientDTO> listClients()
        {
            return DTOAssembler.listClients(_clientRepository.listClients());
        }

        public bool updateClient(ClientDTO client)
        {
            return _clientRepository.updateClient(ModelAssembler.CreateClient(client));
        }
    }
}
