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

namespace Samtel.Api.Services.v1
{
    [RoutePrefix("v1/client")]
    [Authenticate]
    public class ClientController : ApiController
    {
        public readonly IClientAplicationService _clientAplicationService;

        public ClientController(IClientAplicationService clientAplicationService)
        {
            _clientAplicationService = clientAplicationService;
        }

        [HttpGet]
        [Route("getClients")]
        public HttpResponseMessage getClients()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _clientAplicationService.getClients());
        }
    }
}