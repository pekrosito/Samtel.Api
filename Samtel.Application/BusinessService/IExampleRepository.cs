using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samtel.Domain.Models.Entities;
using Samtel.Application.BusinessService.Base;

namespace Samtel.Application.BusinessService
{
    public interface IExampleRepository : IRepository<Person>
    {
        List<Person> metodoSinEntidadYSinVariables();
        IEnumerable<dynamic> metodoDinamico(string variableString);
        IEnumerable<Person> metodoConEntidadConVariables(string variableString, int variableInt);
        Person Save(Person personaRequest);
        Person Update(Person personaRequest);
        Person Delete(Person personaRequest);
    }
}
