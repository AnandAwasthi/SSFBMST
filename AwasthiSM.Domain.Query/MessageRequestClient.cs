using AwasthiSM.ServiceBus;
using MassTransit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AwasthiSM.Domain.Query
{
    public class MessageRequestClient<TRequest, TResponse> : IRequestClient<TRequest, TResponse>
    {
        private ITransitBus _transitBus;
        public MessageRequestClient(ITransitBus transitBus)
        {
            _transitBus = transitBus;
        }
        public Uri Url { get; set; }
        
        public Task<TResponse> Request(TRequest request, CancellationToken cancellationToken)
        {
            var ok = _transitBus.GetBus.CreateRequestClient<TRequest, TResponse>(Url, TimeSpan.FromSeconds(10));
        }
    }
}
