using Samtel.Api.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Samtel.Application.ApplicationServices;
using Samtel.Application.ApplicationServices.DTOs;
using System.Net;

namespace Samtel.Api.Services.v1._0
{
    [RoutePrefix("v1/identifications")]
    [Authenticate]
    public class IdentificationController: ApiController
    {
        public readonly IIdentificationAplicationService _identificationAplicationService;

        public IdentificationController(IIdentificationAplicationService identificationAplicationService)
        {
            _identificationAplicationService = identificationAplicationService;
        }

        [HttpGet]
        [Route("getIdentifications")]
        public HttpResponseMessage getIdentifications()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _identificationAplicationService.getIdentifications());
        }
    }
}