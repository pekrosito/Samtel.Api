using System;
using System.Web;
using System.Web.Http;
using Samtel.Api.App_Start;
using Samtel.Api.Configuration;

namespace Samtel.Api
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            BootstrapperApi.Initialize(NinjectWebCommon.bootstrapper.Kernel, GlobalConfiguration.Configuration);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalConfiguration.Configuration.Filters);
            WebApiConfig.JsonFormater(GlobalConfiguration.Configuration);
            //LogFactory.GetLog("GENERAL").Info("START API");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove("Server");
            Response.Headers.Remove("X-AspNet-Version");
            Response.Headers.Remove("X-Powered-By");
            Response.Headers.Remove("X-Sourcefiles");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            //LogFactory.GetLog("GENERAL").Error("APPLICATION_ERROR", exception);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End()
        {
            // This will give LE background thread some time to finish sending messages to Logentries. 
            var numWaits = 3;
            //while (!LogentriesCore.Net.AsyncLogger.AreAllQueuesEmpty(TimeSpan.FromSeconds(5)) && numWaits > 0)
            numWaits--;
        }
    }
}