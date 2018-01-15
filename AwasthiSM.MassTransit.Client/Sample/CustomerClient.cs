
﻿using AwasthiSM.Domain.Entities.Sample;
using System;
using MassTransit;
using System.Threading.Tasks;
using System.Threading;
using AwasthiSM.ServiceBus;

namespace AwasthiSM.MassTransit.Client.Sample
{
    public class CustomerClient : IRequestClient<CustomerRequest, CustomerResponse>
    {
        private ITransitBus _transitBus;
        public CustomerClient(ITransitBus transitBus)
        {
            _transitBus = transitBus;
        }
        public async Task<CustomerResponse> Request(string url, CustomerRequest requestData, TimeSpan timeSpan,CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return null;
            }
            var requestClient = _transitBus.GetBus.CreateRequestClient<CustomerRequest, CustomerResponse>(new Uri(url), timeSpan);
            return await requestClient.Request(requestData);
        }
    }
}
