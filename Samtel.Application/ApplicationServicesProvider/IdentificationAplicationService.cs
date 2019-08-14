using Samtel.Application.ApplicationServices;
using Samtel.Application.ApplicationServices.DTOs;
using Samtel.Application.ApplicationServicesProvider.Assemblers;
using Samtel.Application.BusinessService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServicesProvider
{
    public class IdentificationAplicationService : IIdentificationAplicationService
    {

         private readonly IIdentificationRepository _identificationRepository;
        private readonly RequestContext _requestContext;

        public IdentificationAplicationService(IIdentificationRepository identificationTransactionsRepository, RequestContext requestContext)
        {
            _identificationRepository = identificationTransactionsRepository;
            _requestContext = requestContext;
        }

        public List<IdentificationDTO> getIdentification()
        {
            return DTOAssembler.listarIdentifications(_identificationRepository.getIdentification());
        }
    }
}
