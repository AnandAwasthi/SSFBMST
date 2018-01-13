using AwasthiSM.Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwasthiSM.External.Service
{
    public abstract class ServiceExecutor 

    {
        public async Task<TResponse> SendAsync<TRequest, TResponse>(CancellationToken cancelToken, HttpRequestMessage<TRequest> request, 
            IDictionary<string, List<string>> headers = null) 
        {
            
            HttpResponseMessage response = null;
            TResponse value = default(TResponse);
            if (headers != null)
                request.AddHeaders(headers);

            using (HttpCommunicationClient client = new HttpCommunicationClient())
                response = await client.HttpClient.SendAsync(request, cancelToken);
            if (response.Content != null && response.IsSuccessStatusCode)
                value = await response.Content.ReadAsAsync<TResponse>(new List<MediaTypeFormatter> { new JsonMediaTypeFormatter() }, cancelToken);
            
            int statusCode = (int)response.StatusCode;
            if ((statusCode >= 500 && statusCode < 600) || statusCode == (int)HttpStatusCode.NotFound)
            {
                throw new HttpResponseException("Service call failed", response);
            }
            return value;
        }
        public async Task<TResponse> SendAsync<TResponse>(CancellationToken cancelToken, HttpRequestMessage
            request, IDictionary<string, List<string>> headers = null)
        {

            HttpResponseMessage response = null;
            TResponse value = default(TResponse);
            if (headers != null)
                request.AddHeaders(headers);

            using (HttpCommunicationClient client = new HttpCommunicationClient())
                response = await client.HttpClient.SendAsync(request, cancelToken);
            if (response.Content != null && response.IsSuccessStatusCode)
                value = await response.Content.ReadAsAsync<TResponse>(new List<MediaTypeFormatter> { new JsonMediaTypeFormatter() }, cancelToken);
            int statusCode = (int)response.StatusCode;
            if ((statusCode >= 500 && statusCode < 600) || statusCode == (int)HttpStatusCode.NotFound)
            {
                throw new HttpResponseException("Service call failed", response);
            }
            return value;
        }
    }
}
