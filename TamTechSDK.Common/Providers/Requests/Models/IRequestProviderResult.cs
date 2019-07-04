using System.Collections.Generic;
using System.Net;
using TamTechSDK.Common.Models.Exceptions;

namespace TamTechSDK.Common.Providers.Requests.Models
{
    public interface IRequestProviderResult<T>
    {
        T Data { get; set; }

        bool Success { get; set; }

        Dictionary<string, List<string>> Messages { get; set; } 

        object Header { get; set; }

        string JsonHeader { get; set; }

        HttpStatusCode StatusCode { get; set; }


      //  string DebugData { get; set; }
    }



    
}
