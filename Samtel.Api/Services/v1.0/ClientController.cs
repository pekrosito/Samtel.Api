using Samtel.Api.Security;
using Samtel.Application.ApplicationServices;
using Samtel.Application.ApplicationServices.DTOs;
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
    
    public class ClientController : ApiController
    {
         public readonly IPersonAplicationService _personAplicationService;

        public ClientController(IPersonAplicationService personAplicationService)
        {
            _ClientAplicationService = personAplicationService;
        }

        [HttpGet]
        [Route("getClient")]
        public HttpResponseMessage getClient()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _ClientAplicationService.getClient());
        }

       

        

       
    }
}
