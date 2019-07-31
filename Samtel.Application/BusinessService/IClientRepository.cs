using Samtel.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.BusinessService
{
    public class IClientRepository
    {
        IEnumerable<Client> metodoSinEntidadYSinVariables();
        IEnumerable<dynamic> metodoDinamico(string variableString);
        IEnumerable<Client> metodoConEntidadConVariables(string variableString, int variableInt);
        Client Save(Client personaRequest);
        Client Update(Client personaRequest);
        Client Delete(Client personaRequest);
    }
}
