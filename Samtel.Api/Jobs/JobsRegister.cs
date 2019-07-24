using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Samtel.Api.App_Start;
using Samtel.Application;
using Hangfire;

namespace Samtel.Api.Jobs
{
    public class JobsRegister
    {
        public static void Register()
        {
            var kernel = NinjectWebCommon.bootstrapper.Kernel;
            var configuration = kernel.Get<IConfigurationManager>();
        }
    }
}