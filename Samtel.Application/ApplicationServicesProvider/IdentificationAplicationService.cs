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
    public class IdentificationAplicationService : IIdentificationAplicationService
    {
        private readonly IIdentificationRepository _identificationRepository;
        private readonly RequestContext _requestContext;

        public IdentificationAplicationService(IIdentificationRepository clientTransactionsRepository, RequestContext requestContext)
        {
            _identificationRepository = clientTransactionsRepository;
            _requestContext = requestContext;
        }

        public List<IdentificationDTO> listIdentifications()
        {
            return DTOAssembler.listIdentifications(_identificationRepository.listIdentifications());
        }
    }
}
