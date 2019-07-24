using System;
using System.Data;
using System.Collections.Generic;
using Samtel.Application;
using Samtel.Domain.Models;
using Samtel.Application.BusinessService;
using Samtel.Application.BusinessService.Base;
using Samtel.Persistence.BusinessServiceProvider.Base;
using Samtel.Domain.Models.Entities;
using Dapper;

namespace Samtel.Persistence.BusinessServiceProvider
{
    public class ExampleRepository : RepositoryBase<Person>, IExampleRepository
    {
        private readonly RepositoryBase<Person> _RepositoryBase;

        public ExampleRepository(IContext context, RequestContext requestContext): base(context, requestContext)
        {
        }

        public IEnumerable<Person> metodoSinEntidadYSinVariables()
        {
            //const string keyCache = "v1/payment-methods_GET";
            //if (_cacheService.Exists(keyCache)) return _cacheService.Get<IEnumerable<PaymentMethod>>(keyCache);

            var testing = ExecuteStoreProcedure<Person>("sel_exampleTables");
            // _cacheService.Add(keyCache, paymentMethods);
            return testing;
        }

        public IEnumerable<Person> metodoConEntidadConVariables(string variableString, int variableInt)
        {
            //const string keyCache = "v1/payment-methods_GET";
            //if (_cacheService.Exists(keyCache)) return _cacheService.Get<IEnumerable<PaymentMethod>>(keyCache);
            var parametros = new DynamicParameters();
            parametros.Add("@Param1", variableInt);
            parametros.Add("@Param2", variableString);

            var testing = ExecuteStoreProcedure<Person>("sel_example_con_parametros", parametros);
            // _cacheService.Add(keyCache, paymentMethods);
            return testing;
        }

        public IEnumerable<dynamic> metodoDinamico(string variable)
        {
            var testing = Query<Person>("sel_exampleTables", CommandType.StoredProcedure);
            //var testing = Query<EntityExample>("SELECT firstName, lastName, edad, id FROM exampleTables");
            return testing;
        }

        public Person Save(Person personaRequest)
        {
            return base.Save(personaRequest);
        }

        public Person Update(Person personaRequest)
        {
            return base.Update(personaRequest);
        }

        public Person Delete(Person personaRequest)
        {
            return base.Delete(personaRequest);
        }
    }
}
