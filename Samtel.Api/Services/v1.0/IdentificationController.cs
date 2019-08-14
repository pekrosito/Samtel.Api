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
    [RoutePrefix("v1/test")]
    [Authenticate]
    public class IdentificationController : ApiController
    {
        public readonly IIdentificationAplicationService _IdentificationAplicationService;

        public IdentificationController(IIdentificationAplicationService identificationAplicationService)
        {
            _IdentificationAplicationService = identificationAplicationService;
        }

        [HttpGet]
        [Route("getIdentification")]
        public HttpResponseMessage getIdentification()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _IdentificationAplicationService.getIdentification());
        }
    }
}
