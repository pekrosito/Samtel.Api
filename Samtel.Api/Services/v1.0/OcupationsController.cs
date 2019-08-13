using Samtel.Api.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Samtel.Application.ApplicationServices;
using Samtel.Application.ApplicationServices.DTOs;
using System.Net.Http;
using System.Net;

namespace Samtel.Api.Services.v1._0
{
    [RoutePrefix("v1/ocupations")]
    [Authenticate]
    public class OcupationsController : ApiController
    {
        public readonly IOcupationsAplicationsService _ocupationsAplicationsService;

        public OcupationsController(IOcupationsAplicationsService ocupationsAplicationsService)
        {
            _ocupationsAplicationsService = ocupationsAplicationsService;
        }

        [HttpGet]
        [Route("getOcupations")]
        public HttpResponseMessage getOcupations()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _ocupationsAplicationsService.getOcupations());
        }
    }
}