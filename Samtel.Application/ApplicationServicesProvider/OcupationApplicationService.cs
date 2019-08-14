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
    public class OcupationApplicationService : IOcupationApplicationService
    {

        private readonly IOcupationRepository _ocupationRepository;
        private readonly RequestContext _requestContext;

        public OcupationApplicationService(IOcupationRepository ocupationsRepository, RequestContext requestContext)
        {
            _ocupationRepository = ocupationsRepository;
            _requestContext = requestContext;
        }

        public List<OcupationDTO> getOcupations()
        {
            return DTOAssembler.listarOcupations(_ocupationRepository.getOcupations());
        }
    }
}
