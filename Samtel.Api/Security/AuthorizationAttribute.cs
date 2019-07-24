using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.Practices.ServiceLocation;
using Samtel.Application.ApplicationServices;
//using Abastible.Sge.Infrastructure.Common.Log;

namespace Samtel.Api.Security
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        //private readonly ILog _log = LogFactory.GetLog<AuthorizationAttribute>();

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            //_log.Debug("Start Authorization");
            var securityService = ServiceLocator.Current.GetInstance<ISecurityService>();
            if (securityService.ValidateAuthorization(actionContext))
            {
                return true;
            }
            UnAuthenticated(actionContext, "");
            return base.IsAuthorized(actionContext);
        }

        private void UnAuthenticated(HttpActionContext actionContext, string statusDescription)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, statusDescription);
        }
    }
}