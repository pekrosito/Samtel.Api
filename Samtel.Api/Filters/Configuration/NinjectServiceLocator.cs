using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Samtel.Api.Configuration
{
    public class NinjectServiceLocator : ServiceLocatorImplBase
    {
        private readonly IKernel _kernel;

        public NinjectServiceLocator(IKernel kernel)
        {
            _kernel = kernel;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (key == null)
            {
                return _kernel.Get(serviceType);
            }
            return _kernel.Get(serviceType, key);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}