using System;
using System.Net.Http;
using System.Runtime.Serialization;

namespace AwasthiSM.External.Service
{
    [Serializable]
    internal class HttpResponseException : Exception
    {
        public HttpResponseMessage Response { get; }

        public HttpResponseException()
        {
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpResponseException(string message, HttpResponseMessage response)
            : this(message)
        {
            Response = response;
        }
    }
}