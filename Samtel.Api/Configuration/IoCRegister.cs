using System.Web.Http;
using FluentValidation;
using Ninject;
using Ninject.Web.Common;
using Samtel.Application.ApplicationServices;
using Samtel.Application;
using Samtel.Persistence.Dapper;
using Samtel.Application.BusinessService.Base;
using Samtel.Persistence.BusinessServiceProvider;
using Samtel.Application.ApplicationServicesProvider;
using Samtel.Persistence.BusinessServiceProvider.Base;
using Samtel.Application.ServiceAgents;
using Samtel.Infraestructure.Security.Token;
using Samtel.Infraestructure.CacheServices;
using Samtel.Application.BusinessService;

namespace Samtel.Api.Configuration
{
    public static class IoCRegister
    {
        public static void Register(IKernel kernel)
        {
            RegisterApiController(kernel);
            RegisterApplicationService(kernel);
            RegisterModelService(kernel);
            RegisterRepositories(kernel);
            RegisterServiceAgents(kernel);
        }

        private static void RegisterServiceAgents(IKernel kernel)
        {
            kernel.Bind<IAuthentication>().To<TokenAuthentication>().InTransientScope();
            kernel.Bind<ILocalCacheService>().ToConstant(new LocalCacheService());
        }

        private static void RegisterRepositories(IKernel kernel)
        {
            kernel.Bind<IContext>().To<DapperContext>().InRequestScope();
            kernel.Bind<IUnitOfwork>().To<UnitOfWork>().InRequestScope();

            kernel.Bind(typeof(IRepository<>)).To(typeof(RepositoryBase<>)).InRequestScope();
            kernel.Bind<IExampleRepository>().To<ExampleRepository>().InRequestScope();
            kernel.Bind<IParameterRepository>().To<Samtel.Persistence.BusinessServiceProvider.ParameterRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
        }

        private static void RegisterModelService(IKernel kernel)
        {
            kernel.Bind<RequestContext>().To<RequestContext>().InRequestScope();
            kernel.Bind<ISecurityService>().To<SecurityService>().InTransientScope();
        }

        private static void RegisterApplicationService(IKernel kernel)
        {
            kernel.Bind<IExampleAplicationService>().To<ExampleServices>();
        }

        private static void RegisterApiController(IKernel kernel)
        {
            kernel.Bind<IConfigurationManager>().To<RestConfigurationManager>();

            AssemblyScanner
                .FindValidatorsInAssembly(typeof(ApiController).Assembly)
                .ForEach(result => kernel.Bind(result.InterfaceType)
                    .To(result.ValidatorType)
                    .InRequestScope());
        }
    }
}