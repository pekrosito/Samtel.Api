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
    public class GeneralApplicationService: IGeneralApplicationService
    {

         private readonly IGeneralRepository _generalRepository;
        private readonly RequestContext _requestContext;

        public GeneralApplicationService(IGeneralRepository generalTransactionsRepository, RequestContext requestContext)
        {
            _generalRepository = generalTransactionsRepository;
            _requestContext = requestContext;
        }

        public List<GeneralDTO> getIdentification()
        {
            return DTOAssembler.listarIdentifications2(_generalRepository.getIdentification());
        }
        public List<GeneralDTO> getOcupations()
        {
            return DTOAssembler.listarOcupations2(_generalRepository.getOcupations());
        }
    }
}
