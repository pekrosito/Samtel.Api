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
    public class CreditApplicationService : ICreditApplicationService
    {
        private readonly ICreditRepository _creditRepository;
        private readonly RequestContext _requestContext;

        public CreditApplicationService (ICreditRepository creditRepository, RequestContext requestContext)
    {
        _creditRepository= creditRepository;
        _requestContext = requestContext;

    }


        //public CreditDTO getCredits()
        //{
        //    return DTOAssembler.CreateCredit(_creditRepository.getCredits());
        //}
      
        public List<CreditDTO> getCredits()
        {
            return DTOAssembler.listarCredits(_creditRepository.getCredits());
        }
    }
}
