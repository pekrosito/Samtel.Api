using Samtel.Api.Security;
using Samtel.Application.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Samtel.Api.Services.v1._0
{

    [RoutePrefix("v1/Credit")]
    [Authenticate]
    public class CreditController : ApiController
    {
        public readonly ICreditApplicationService _creditAplicationService;

        public CreditController(ICreditApplicationService creditAplicationService)
        {
            _creditAplicationService = creditAplicationService;
        }

        [HttpGet]
        [Route("getCredits")]
        public HttpResponseMessage getCredits()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _creditAplicationService.getCredits());
        }
    }
}
