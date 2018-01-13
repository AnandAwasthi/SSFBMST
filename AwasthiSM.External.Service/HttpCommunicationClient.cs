using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwasthiSM.External.Service
{
    public class HttpCommunicationClient :IDisposable
    {
        private HttpClient _httpClient;
        public HttpCommunicationClient()
        {
            _httpClient = new HttpClient();
        }
        public HttpClient HttpClient { get { return _httpClient; } private set { _httpClient = value; } }
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
