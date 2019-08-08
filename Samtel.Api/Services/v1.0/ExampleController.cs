using Samtel.Api.Security;
using Samtel.Application.ApplicationServices;
using Samtel.Application.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Samtel.Api.Services.v1
{
    [RoutePrefix("v1/test")]
    [Authenticate]
    //[Authorization]
    public class ExampleController : ApiController
    {
        public readonly IExampleAplicationService _ExampleAplicationService;

        public ExampleController(IExampleAplicationService exampleAplicationService)
        {
            _ExampleAplicationService = exampleAplicationService;
        }

        [HttpGet]
        [Route("metodoGetSinVariable")]
        public HttpResponseMessage metodoGetSinVariable()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _ExampleAplicationService.consultaSinVariable());
        }

        [HttpGet]
        [Route("metodoGetConVariable/{variableInt}")]
        public HttpResponseMessage metodoGetConVariable(int variableInt, string variableString)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _ExampleAplicationService.consultaConVariable(variableString, variableInt));
        }

        [HttpPost]
        [Route("metodoPost")]
        public HttpResponseMessage metodoPost(PersonDTO personaRequest)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _ExampleAplicationService.metodoPost(personaRequest));
        }

        [HttpPut]
        [Route("metodoPutActualizar")]
        public HttpResponseMessage metodoPut(PersonDTO personaRequest)
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, _ExampleAplicationService.metodoPut(personaRequest));
        }

        [HttpDelete]
        [Route("metodoEliminar")]
        public HttpResponseMessage metodoEliminar(PersonDTO personaRequest)
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, _ExampleAplicationService.metodoEliminar(personaRequest));
        }
    }
    
}