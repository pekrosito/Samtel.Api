using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Samtel.Application.ApplicationServices;
using Samtel.Application.ApplicationServices.DTOs;
using Samtel.Application.BusinessService;
using Samtel.Application;
using Samtel.Application.ApplicationServicesProvider.Assemblers;

namespace Samtel.Application.ApplicationServicesProvider
{
    public class ExampleServices : IExampleAplicationService
    {
        private readonly IExampleRepository _exampleRepository;
        private readonly RequestContext _requestContext;

        public ExampleServices(IExampleRepository exampleTransactionsRepository, RequestContext requestContext)
        {
            _exampleRepository = exampleTransactionsRepository;
            _requestContext = requestContext;
        }

        public List<PersonDTO> consultaSinVariable()
        {
            return DTOAssembler.CreatePersons(_exampleRepository.metodoSinEntidadYSinVariables());
        }

        public IEnumerable<PersonDTO> consultaConVariable(string variableString, int variableInt)
        {
            IEnumerable<PersonDTO> A = null;
            
            var dataExample = _exampleRepository.metodoConEntidadConVariables(variableString, variableInt);

            return A;
        }

        public bool metodoPost(PersonDTO personaRequest)
        {
            try
            {
                var persona = new PersonDTO
                {
                  
                };

                //_exampleRepository.Save(persona);
            }
            catch (SqlException ex)
            {

            }

            return true;
        }

        public bool metodoPut(PersonDTO personaRequest)
        {
            try
            {
                var persona = new PersonDTO
                {
                   
                };

                //_exampleRepository.Update(persona);

            }
            catch (SqlException ex)
            {

            }

            return true;
        }

        public bool metodoEliminar(PersonDTO personaRequest)
        {
            try
            {
                var persona = new PersonDTO
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
