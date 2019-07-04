using System.Collections.Generic;
using System.Net;
using TamTechSDK.Common.Models.Exceptions;

namespace TamTechSDK.Common.Providers.Requests.Models
{
    public class RequestProviderResult<T> : IRequestProviderResult<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public Dictionary<string, List<string>> Messages { get; set; }

        public string DebugData { get; set; }

        public object Header { get; set; }

        public string JsonHeader { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public ExceptionResponse Exception { get; set; }

        
    }
}
