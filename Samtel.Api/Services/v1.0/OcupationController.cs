using Samtel.Api.Security;
using Samtel.Application.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Samtel.Api.Services.v1
{
    [RoutePrefix("v1/test")]
    [Authenticate]
    public class OcupationController : ApiController
    {
        
        public readonly IOcupationApplicationService _OcupationAplicationService;

        public OcupationController(IOcupationApplicationService ocupationAplicationService)
        {
            _OcupationAplicationService = ocupationAplicationService;
        }
        // GET: api/Ocupation
        [HttpGet]
        [Route("getOcupations")]
        public HttpResponseMessage getOcupations()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _OcupationAplicationService.getOcupations());
        }
    }
}
