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
    public class IdentificationAplicationService: IIdentificationAplicationService
    {
        private readonly IIdentificationRepository _identificationRepository;
        private readonly RequestContext _requestContext;

        public IdentificationAplicationService(IIdentificationRepository IdentificationsTransactionsRepository, RequestContext requestContext)
        {
            _identificationRepository = IdentificationsTransactionsRepository;
            _requestContext = requestContext;
        }

        public IEnumerable<OcupationsDTO> getIdentifications()
        {
            return DTOAssembler.ConvertEntityaDtoOcupation2(_identificationRepository.getIdentifications());
        }
    }
}

