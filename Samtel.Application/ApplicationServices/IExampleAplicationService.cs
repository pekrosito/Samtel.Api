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
        IEnumerable<ExampleDTO> consultaSinVariable();
        IEnumerable<ExampleDTO> consultaConVariable(string variableString, int variableInt);
        bool metodoPost(ExampleDTO personaRequest);
        bool metodoPut(ExampleDTO personaRequest);
        bool metodoEliminar(ExampleDTO personaRequest);
    }
}
