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
    [RoutePrefix("v1/general")]
    [Authenticate]
    public class GeneralController : ApiController
    {
        public readonly IGeneralApplicationService _GeneralAplicationService;

    public GeneralController(IGeneralApplicationService generalnAplicationService)
        {
            _GeneralAplicationService = generalnAplicationService;
        }

        [HttpGet]
        [Route("getIdentification")]
        public HttpResponseMessage getIdentification()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _GeneralAplicationService.getIdentification());
        }
        [HttpGet]
        [Route("getOcupations")]
        public HttpResponseMessage getOcupations()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _GeneralAplicationService.getOcupations());
        }
    }
}
