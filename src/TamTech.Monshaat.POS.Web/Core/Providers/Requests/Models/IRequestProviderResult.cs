using System.Collections.Generic;
using System.Net; 

namespace TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models
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
