using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Application.ApplicationServices;
using Samtel.Application.ApplicationServices.DTOs;
using Samtel.Application.ApplicationServicesProvider.Assemblers;
using Samtel.Application.BusinessService;

namespace Samtel.Application.ApplicationServicesProvider
{
    public class ClientAplicationServicesService : IClientAplicationService
    {
        private readonly IClientRepository _clientRepository;
        private readonly RequestContext _requestContext;

        public ClientAplicationServicesService(IClientRepository clientRepository, RequestContext requestContext)
        {
            _clientRepository = clientRepository;
            _requestContext = requestContext;
        }
        public List<ClientDTO> getClients()
        {
            return DTOAssembler.CreateClients(_clientRepository.getClients());
        }
    }
}
