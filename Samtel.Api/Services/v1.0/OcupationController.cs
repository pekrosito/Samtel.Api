using Samtel.Api.Security;
using Samtel.Application.ApplicationServices;
using Samtel.Application.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Samtel.Api.Services.v1
{
    
    [RoutePrefix("v1/ocupation")]
    [Authenticate]
    //[Authorization]
    public class OcupationController : ApiController
    {
        public readonly IOcupationAplicationService _IOcupationAplicationService;

        public OcupationController(IOcupationAplicationService iOcupationAplicationService)
        {
            _IOcupationAplicationService = iOcupationAplicationService;
        }

        [HttpGet]
        [Route("getOcupations")]
        public HttpResponseMessage getOcupations()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _IOcupationAplicationService.listOcupations());
        }
    }
}
