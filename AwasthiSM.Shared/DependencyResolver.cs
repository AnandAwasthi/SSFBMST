using System;
using Microsoft.Extensions.DependencyInjection;
namespace AwasthiSM.Shared
{
    public class DependencyResolver
    {
        private static DependencyResolver _resolver;

        public static DependencyResolver Current
        {
            get
            {
                if (_resolver == null)
                    throw new Exception("AppDependencyResolver not initialized. You should initialize it in Startup class");
                return _resolver;
            }
        }

        public static void Init(IServiceProvider services)
        {
            _resolver = new DependencyResolver(services);
        }

        private readonly IServiceProvider _serviceProvider;

        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        private DependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
