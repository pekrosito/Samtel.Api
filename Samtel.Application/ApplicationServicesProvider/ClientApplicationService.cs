using Samtel.Application.ApplicationServices;
using Samtel.Application.ApplicationServicesProvider.Assemblers;
using Samtel.Application.BusinessService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServicesProvider
{
    public class ClientApplicationService :IClientApplicationService
    {
        private readonly IClientRepository _clientRepository;
        private readonly RequestContext _requestContext;

        public ClientApplicationService (IClientRepository clientRepository,RequestContext requestContext)
        {
            _clientRepository = clientRepository;
            _requestContext = requestContext;
        }

        public List<ApplicationServices.DTOs.ClientDTO> getClients()
        {
            return DTOAssembler.listarClientes(_clientRepository.getClients());
        }
    }
}
