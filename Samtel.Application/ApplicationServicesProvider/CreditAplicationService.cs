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
   public class CreditAplicationService : ICreditAplicationService
    {
        private readonly ICreditRepository _creditRepository;
        private readonly RequestContext _requestContext;

        public CreditAplicationService(ICreditRepository crediTransactionsRepository, RequestContext requestContext)
        {
            _creditRepository = crediTransactionsRepository;
            _requestContext = requestContext;
        }


        public List<CreditDTO> listCredits()
        {
            return DTOAssembler.listCredits(_creditRepository.listCredits());
        }


        public bool metodoPost(CreditDTO credit)
        {
            return _creditRepository.metodoPost(ModelAssembler.CreateCredit(credit));
             
        }


        public bool metodoEliminar(int id)
        {
            return _creditRepository.metodoEliminar(id);
        }


        public bool metodoActualizar(CreditDTO credit, int id)
        {
            return _creditRepository.metodoActualizar(ModelAssembler.CreateCredit(credit),id);
        }
    }
}
