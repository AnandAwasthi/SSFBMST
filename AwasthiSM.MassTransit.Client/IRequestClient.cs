﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace AwasthiSM.MassTransit.Client
{
    public interface IRequestClient<TRequest, TResponse>
    {
        Task<TResponse> Request(string url, TRequest request, TimeSpan timeSpan, CancellationToken cancellationToken);
    }
}
