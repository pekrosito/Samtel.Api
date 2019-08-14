using Samtel.Api.Security;
using Samtel.Application.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Samtel.Api.Services.v1
{
    [RoutePrefix("v1/Client")]
    [Authenticate]
    public class ClientController : ApiController
    {
        public readonly IClientApplicationService _clientAplicationService;

        public ClientController(IClientApplicationService clientAplicationService)
        {
            _clientAplicationService = clientAplicationService;
        }

        [HttpGet]
        [Route("getClients")]
        public HttpResponseMessage GetClients()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _clientAplicationService.getClients());
        }
    }
}