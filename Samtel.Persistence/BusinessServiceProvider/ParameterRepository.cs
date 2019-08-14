using System;
using System.Linq;
using Samtel.Application;
using Samtel.Application.Exceptions;
using Samtel.Domain.Models;
using Samtel.Application.BusinessService;
using Samtel.Application.BusinessService.Base;
using Samtel.Application.ServiceAgents;
using Samtel.Persistence.BusinessServiceProvider.Base;
using Samtel.Domain.Models.Config;

namespace Samtel.Persistence.BusinessServiceProvider
{
    public class ParameterRepository : RepositoryBase<Parameter>, IParameterRepository
    {
        //private readonly IDistribuitedCacheService _cacheService;
       // IDistribuitedCacheService cacheService;
        public ParameterRepository(IContext context, RequestContext requestContext) : base(context, requestContext)
        {
            //_cacheService = cacheService;
        }

        public string GetValue(string parameterName)
        {
            //$
           // var key = "parameter_{parameterName}";
            //if (_cacheService.Exists(key)) return _cacheService.Get<string>(key);

            var parameter = Query<Parameter>(@"select * from Parameters where Name = @parameterName ", new { parameterName }).SingleOrDefault();

            if (parameter == null) throw new AutorizationException("PARAMETRO NO CONFIGURADO", ErrorTypes.SystemParameterNotConfigured);
            //_cacheService.Add(key, parameter.Value);
            return parameter.Value;// _cacheService.Get<string>(key);
        }

        public void SaveOrUpdate(Parameter parameter)
        {
            var exists = Query<Parameter>(@"select * from Parameters where Name = @parameterName ", new { parameterName = parameter.Name }).SingleOrDefault();
            if (exists != null)
            {
                exists.Value = parameter.Value;
                exists.Description = parameter.Description;
                base.Update(parameter);
                //$
               // var key = "parameter_{parameter.Name}";
                //if (_cacheService.Exists(key)) _cacheService.Remove(key);
            }
            else
            {
                base.Save(parameter);
            }
        }
    }
}
