using System.Web.Http;
using FluentValidation.WebApi;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Samtel.Api.Jobs;
//using Samtel.Infrastructure.Common.Log;
using Samtel.Persistence.Dapper;

namespace Samtel.Api.Configuration
{
    public class BootstrapperApi
    {
        public static void Initialize(IKernel kernel, HttpConfiguration configuration)
        {
            //LogFactory.Configure();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));
            ConfigurationDapper.Init();

            configuration.MessageHandlers.Insert(0, new ThreadCultureMessageHandler());

            FluentValidationModelValidatorProvider.Configure(configuration, provider => provider.ValidatorFactory = new NinjectValidatorFactory(kernel));

            //hangfire server initialization
            HangfireBootstrapper.Instance.Start();
            JobsRegister.Register();
        }

        public static void ShutDown()
        {
            HangfireBootstrapper.Instance.Stop();
        }
    }
}