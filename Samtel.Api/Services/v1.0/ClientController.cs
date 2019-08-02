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
       
        [HttpDelete]
        [Route("delClientById/{id}")]
        public HttpResponseMessage deleteClientById(int id)
        {
           //return Request.CreateResponse(HttpStatusCode.OK, "Hola");

           /* if (_clientAplicationService.deleteClientById(id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "aaaa");
            }
            else {
                return Request.CreateResponse(HttpStatusCode.OK, "bbb");
            }*/
            return Request.CreateResponse(HttpStatusCode.Accepted, _clientAplicationService.deleteClientById(id));
        }

        // es tipo post poque le envio parametros
        [HttpPost]
        [Route("createClient")]
        public HttpResponseMessage createClient(ClientDTO clientRequest)
        {
            return Request.CreateResponse(HttpStatusCode.Created, _clientAplicationService.createClient(clientRequest));
        }

        [HttpPut]
        [Route("editClient/{id}")]
        public HttpResponseMessage editClient(int id,  ClientDTO clientRequest)
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, _clientAplicationService.editClient(id, clientRequest));
        }
    }
}