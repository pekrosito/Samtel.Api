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
    public class OcupationAplicationService : IOcupationAplicationService
    {
        private readonly IOcupationRepository _ocupationRepository;
        private readonly RequestContext _requestContext;

        public OcupationAplicationService(IOcupationRepository ocupationTransactionsRepository, RequestContext requestContext)
        {
            _ocupationRepository = ocupationTransactionsRepository;
            _requestContext = requestContext;
        }

        public List<OcupationDTO> listOcupations()
        {
            return DTOAssembler.listOcupations(_ocupationRepository.listOcupations());             
        }
    }
}
