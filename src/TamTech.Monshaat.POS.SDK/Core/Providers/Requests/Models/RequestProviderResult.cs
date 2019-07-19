using System.Collections.Generic;
using System.Net; 

namespace TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models
{
    public class RequestProviderResult<T> : IRequestProviderResult<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public Dictionary<string, List<string>> Messages { get; set; }

        public HttpStatusCode StatusCode { get; set; } 
         
        public object Header { get; set; }

        public string JsonHeader { get; set; } 
        public string JsonContent { get; set; } 

        public void AddError(string key, string errorMessage)
        {
            if (Messages == null)
            {
                Messages = new Dictionary<string, List<string>> { { key, new List<string> { errorMessage } } };
                return;
            }
            if (Messages.ContainsKey(key))
            {
                List<string> value = Messages[key];
                value.Add(errorMessage);
                Messages[key] = value;
            }
            else
            {
                Messages.Add(key, new List<string> { errorMessage });
            }
        } 
    }


    public class RequestProviderErrors
    {
        public Dictionary<string, List<string>> Errors { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
