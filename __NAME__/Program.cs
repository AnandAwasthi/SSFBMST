using Microsoft.AspNetCore.Hosting;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using System.Collections.Generic;
using System.Fabric;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace __NAME__
{
    internal static class Program
    {
        // Entry point for the application.
        public static void Main(string[] args)
        {
            ServiceRuntime.RegisterServiceAsync("__NAME__Type", context => new WebHostingService(context, "ServiceEndpoint")).GetAwaiter().GetResult();
            //Register.Service("__NAME__Type", "ServiceEndpoint");
            Thread.Sleep(Timeout.Infinite);
        }
        /// <summary>
        /// A specialized stateless service for hosting ASP.NET Core web apps.
        /// </summary>
        internal sealed class WebHostingService : StatelessService, ICommunicationListener
        {
            private readonly string _endpointName;

            private IWebHost _webHost;

            public WebHostingService(StatelessServiceContext serviceContext, string endpointName)
                : base(serviceContext)
            {
                _endpointName = endpointName;
            }

            #region StatelessService

            protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
            {
                return new[] { new ServiceInstanceListener(_ => this) };
            }

            #endregion StatelessService

            #region ICommunicationListener

            void ICommunicationListener.Abort()
            {
                _webHost?.Dispose();
            }

            Task ICommunicationListener.CloseAsync(CancellationToken cancellationToken)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return null;
                }
                _webHost?.Dispose();

                return Task.FromResult(true);
            }

            Task<string> ICommunicationListener.OpenAsync(CancellationToken cancellationToken)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return null;
                }
                var endpoint = FabricRuntime.GetActivationContext().GetEndpoint(_endpointName);

                string serverUrl = $"{endpoint.Protocol}://{FabricRuntime.GetNodeContext().IPAddressOrFQDN}:{endpoint.Port}";

                _webHost = new WebHostBuilder().UseKestrel()
                                               .UseContentRoot(Directory.GetCurrentDirectory())
                                               .UseStartup<Startup>()
                                               .UseUrls(serverUrl)
                                               .Build();

                _webHost.Start();

                return Task.FromResult(serverUrl);
            }

            #endregion ICommunicationListener
        }
    }
}
