using Samtel.Api.Security;
using Samtel.Application.ApplicationServices;
using Samtel.Application.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Samtel.Api.Services.v1._0
{
    [RoutePrefix("v1/credit")]
    [Authenticate]
    //[Authorization]
    public class CreditController : ApiController
    {
        public readonly ICreditAplicationService _CreditAplicationService;

        public CreditController(ICreditAplicationService creditAplicationService)
        {
            _CreditAplicationService = creditAplicationService;
        }

        [HttpGet]
        [Route("getCredits")]
        public HttpResponseMessage getCredits()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _CreditAplicationService.listCredits());
        }

        [HttpPost]
        [Route("postCredit")]
        public HttpResponseMessage postCredit(CreditDTO credit)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _CreditAplicationService.metodoPost(credit));
        }

        [HttpDelete]
        [Route("deleteCredit/{identificacion}")]
        public HttpResponseMessage deleteCredit(int identificacion)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _CreditAplicationService.metodoEliminar(identificacion));
        }

        [HttpPut]
        [Route("editCredit/{id}")]
        public HttpResponseMessage editCredit(CreditDTO credit,int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _CreditAplicationService.metodoActualizar(credit,id));
        }
    }
}
