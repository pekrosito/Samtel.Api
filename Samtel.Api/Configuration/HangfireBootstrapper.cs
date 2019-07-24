using System.Security.Claims;
using System.Web;
using System.Web.Hosting;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Ninject;
using Owin;
using Samtel.Api.App_Start;
using Samtel.Application;

namespace Samtel.Api.Configuration
{
    public class HangfireBootstrapper : IRegisteredObject
    {
        public static readonly HangfireBootstrapper Instance = new HangfireBootstrapper();

        private readonly object _lockObject = new object();
        private bool _started;

        private BackgroundJobServer _backgroundJobServer;

        private HangfireBootstrapper() { }

        public void Start()
        {
            lock (_lockObject)
            {
                if (_started) return;
                _started = true;

                HostingEnvironment.RegisterObject(this);
                GlobalConfiguration.Configuration.UseSqlServerStorage("SGE", new SqlServerStorageOptions { PrepareSchemaIfNecessary = true });
                GlobalConfiguration.Configuration.UseNinjectActivator(new Ninject.Web.Common.Bootstrapper().Kernel);
                _backgroundJobServer = new BackgroundJobServer();
            }
        }

        public void Stop()
        {
            lock (_lockObject)
            {
                if (_backgroundJobServer != null)
                {
                    _backgroundJobServer.Dispose();
                }

                HostingEnvironment.UnregisterObject(this);
            }
        }

        void IRegisteredObject.Stop(bool immediate)
        {
            Stop();
        }

        public void ConfigureOwinStartup(IAppBuilder app)
        {
            var configurationManager = NinjectWebCommon.bootstrapper.Kernel.Get<IConfigurationManager>();

            var options = new DashboardOptions
            {
                AuthorizationFilters = new[] { new ClaimsBasedAuthorizationFilter(ClaimTypes.Role, "Administrador") },
                AppPath = configurationManager.UrlOffice()//ConfigurationManager.AppSettings["Office:urlBase"]//
            };

            //TODO: HANGFIRE - Usar config para definir path a dashboard y path de retorno a App
#if DEBUG
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/login"),
                Provider = new CookieAuthenticationProvider()
                {
                    OnApplyRedirect = ctx =>
                    {
                        if (ctx.Request.Uri.LocalPath.StartsWith(options.AppPath))
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                    }
                }
            });

#else
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/login"),
                Provider = new CookieAuthenticationProvider()
                {
                    OnApplyRedirect = ctx =>
                    {
                        if (ctx.Request.Uri.LocalPath.StartsWith(options.AppPath))
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                    }
                }
            });
#endif
            app.UseHangfireDashboard(configurationManager.RelativeUrlProcessMonitor(), options);
            app.UseHangfireServer();
        }
    }
}