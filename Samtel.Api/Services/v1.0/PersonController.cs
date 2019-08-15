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
    [RoutePrefix("v1/Person")]
    [Authenticate]
    public class PersonController : ApiController
    {
        public readonly IPersonAplicationService _personAplicationService;

        public PersonController(IPersonAplicationService personAplicationService)
        {
            _personAplicationService = personAplicationService;
        }

        [HttpGet]
        [Route("getPersons")]
        public HttpResponseMessage getPersons()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _personAplicationService.getPersons());
            
        }
    }
}
