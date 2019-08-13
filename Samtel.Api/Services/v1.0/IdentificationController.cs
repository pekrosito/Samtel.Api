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
    [RoutePrefix("v1/identification")]
    [Authenticate]
    //[Authorization]
    public class IdentificationController : ApiController
    {
        public readonly IIdentificationAplicationService _IidentificationAplicationService;

        public IdentificationController(IIdentificationAplicationService identificationAplicationService)
        {
            _IidentificationAplicationService = identificationAplicationService;
        }

        [HttpGet]
        [Route("getIdentifications")]
        public HttpResponseMessage getIdentifications()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _IidentificationAplicationService.listIdentifications());
        }

       
    }
}
