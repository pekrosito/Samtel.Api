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
    public class OcupationsAplicationsService : IOcupationsAplicationsService
    {
        private readonly IOcupationsRepository _ocupationsRepository;
        private readonly RequestContext _requestContext;

        public OcupationsAplicationsService(IOcupationsRepository OcupationsTransactionsRepository, RequestContext requestContext)
        {
            _ocupationsRepository = OcupationsTransactionsRepository;
            _requestContext = requestContext;
        }

        public IEnumerable<OcupationsDTO> getOcupations()
        {
            return DTOAssembler.ConvertEntityaDtoOcupation(_ocupationsRepository.getOcupations());
        }
    }
}
