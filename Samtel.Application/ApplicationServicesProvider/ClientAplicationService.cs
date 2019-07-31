using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ApplicationServicesProvider
{
    class ClientAplicationService
    {
         private readonly IExampleRepository _exampleRepository;
        private readonly RequestContext _requestContext;

        public ExampleServices(IExampleRepository exampleTransactionsRepository, RequestContext requestContext)
        {
            _exampleRepository = exampleTransactionsRepository;
            _requestContext = requestContext;
        }

        public IEnumerable<ExampleDTO> consultaSinVariable()
        {
            IEnumerable<ExampleDTO> A = null;

            var dataExample = _exampleRepository.metodoSinEntidadYSinVariables();

            return A;
        }

        public IEnumerable<ExampleDTO> consultaConVariable(string variableString, int variableInt)
        {
            IEnumerable<ExampleDTO> A = null;
            
            var dataExample = _exampleRepository.metodoConEntidadConVariables(variableString, variableInt);

            return A;
        }

        public bool metodoPost(ExampleDTO personaRequest)
        {
            try
            {
                var persona = new ExampleDTO
                {
                  
                };

                //_exampleRepository.Save(persona);
            }
            catch (SqlException ex)
            {

            }

            return true;
        }

        public bool metodoPut(ExampleDTO personaRequest)
        {
            try
            {
                var persona = new ExampleDTO
                {
                   
                };

                //_exampleRepository.Update(persona);

            }
            catch (SqlException ex)
            {

            }

            return true;
        }

        public bool metodoEliminar(ExampleDTO personaRequest)
        {
            try
            {
                var persona = new ExampleDTO
                {
                    
                };

                //_exampleRepository.Delete(persona);
            }
            catch (SqlException ex)
            {

            }

            return true;
        }
    }
}
