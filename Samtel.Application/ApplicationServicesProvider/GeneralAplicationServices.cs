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
    public class GeneralAplicationServices : IGeneralAplicationService
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly RequestContext _requestContext;

        public GeneralAplicationServices(IGeneralRepository generalRepository, RequestContext requestContext)
        {
            _generalRepository = generalRepository;
            _requestContext = requestContext;
        }
        public List<GeneralDTO> getOcupations()
        {
            return DTOAssembler.CreateGenerals(_generalRepository.getOcupations());
        }

        public List<GeneralDTO> getIdentifications()
        {
            return DTOAssembler.CreateGenerals(_generalRepository.getIdentifications());
        }
    }
}
