using Samtel.Application.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServices
{
   public interface IClientAplicationService
    {
        IEnumerable<ClientDTO> consultaSinVariable();
        IEnumerable<ClientDTO> consultaConVariable(string variableString, int variableInt);
        bool metodoPost(ClientDTO personaRequest);
        bool metodoPut(ClientDTO personaRequest);
        bool metodoEliminar(ClientDTO personaRequest);
    }
}
