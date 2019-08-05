using System;
using System.Collections.Generic;
using Samtel.Application.ApplicationServices.DTOs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServices
{
    public interface IExampleAplicationService
    {
        List<PersonDTO> consultaSinVariable();
        IEnumerable<PersonDTO> consultaConVariable(string variableString, int variableInt);
        bool metodoPost(PersonDTO personaRequest);
        bool metodoPut(PersonDTO personaRequest);
        bool metodoEliminar(PersonDTO personaRequest);
    }
}
