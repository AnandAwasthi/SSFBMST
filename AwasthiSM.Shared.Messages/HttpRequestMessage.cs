using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace AwasthiSM.Shared.Messages
{
    public class HttpRequestMessage<T> : HttpRequestMessage
    {
        public HttpRequestMessage(Uri requestUri, HttpMethod httpMethod, T value = default(T), MediaTypeFormatter formatter = null)
        {
            Method = httpMethod;
            RequestUri = requestUri;
            if (value != null)
                Content = new ObjectContent<T>(value, formatter);
        }
    }
}
