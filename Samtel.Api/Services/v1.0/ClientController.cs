﻿using Samtel.Api.Security;
using Samtel.Application.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Samtel.Api.Services.v1
{
  
    [RoutePrefix("v1/Client")]
    [Authenticate]

    public class ClientController : ApiController
    {
        public readonly IClientAplicationService _ClientAplicationService;

        public ClientController(IClientAplicationService clientAplicationService)
        {
            _ClientAplicationService = clientAplicationService;
        }

        [HttpGet]
        [Route("getClients")]
        public HttpResponseMessage getClients()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _ClientAplicationService.listClients());
        }
    }
}
