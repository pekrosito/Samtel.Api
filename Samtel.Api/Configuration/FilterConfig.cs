using System.Web.Http.Filters;
using Samtel.Api.Filters;

namespace Samtel.Api.Configuration
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            //Los filtros se ejecutan en orden cuando se agregan.
            filters.Add(new LogsAdditionalInfoAttribute());
            filters.Add(new RestfulModelStateFilterAttribute());
            filters.Add(new ConfigurationHeaderFilter());
            //filters.Add(new ProcessWorkersFilter());
            filters.Add(new CustomExceptionFilterAttribute());
            filters.Add(new SessionRequestFilter());
        }
    }
}