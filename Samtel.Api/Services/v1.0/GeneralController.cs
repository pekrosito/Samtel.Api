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
    [RoutePrefix("v1/General")]
    [Authenticate]
    public class GeneralController : ApiController
    {
        public readonly IGeneralAplicationService _generalAplicationService;

        public GeneralController(IGeneralAplicationService generalAplicationService)
        {
            _generalAplicationService = generalAplicationService;
        }

        [HttpGet]
        [Route("getOcupations")]
        public HttpResponseMessage getOcupations()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _generalAplicationService.getOcupations());
        }

        [HttpGet]
        [Route("getIdentifications")]
        public HttpResponseMessage getIdentifications()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _generalAplicationService.getIdentifications());
        }
    }
}
