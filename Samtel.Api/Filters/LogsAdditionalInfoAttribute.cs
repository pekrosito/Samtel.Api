using System.Web.Http.Controllers;
using System.Web.Http.Filters;
//using Abastible.Bdg.Infrastructure.Common.Cryptography;
//using Abastible.Bdg.Infrastructure.Common.Log;

namespace Samtel.Api.Filters
{
    public class LogsAdditionalInfoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //var log = LogFactory.GetLog("CONFIG");
            //log.AddThreadContext("RequestIdentifier", "1234567890");
            base.OnActionExecuting(actionContext);
        }
    }
}