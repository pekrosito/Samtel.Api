using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.Practices.ServiceLocation;
using Samtel.Application;
using Samtel.Domain.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http.ModelBinding;

namespace Samtel.Api.Filters
{
    public class ConfigurationHeaderFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var requestContext = ServiceLocator.Current.GetInstance<RequestContext>();
            if (actionContext.Request.Headers.Contains("X-System"))
            {
                SystemType system;
                if (System.Enum.TryParse(actionContext.Request.Headers.GetValues("X-System").SingleOrDefault(), out system))
                {
                    requestContext.System = system;
                    //LogFactory.GetLog("CONFIG").AddThreadContext("SystemSge", requestContext.System.ToString());
                    //return true;
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.BadRequest, new ApiResourceValidationErrorWrapper(actionContext.ModelState));
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.BadRequest, new ApiResourceValidationErrorWrapper(actionContext.ModelState));
            }
        }
    }
}