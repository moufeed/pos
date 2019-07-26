using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;           

namespace TamTech.Monshaat.POS.Web.SDK.Core.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetRootUrl(this HttpRequest request )
        {    
          string  rootUrl = string.Format("{0}://{1}{2}", request.Scheme, request.Host, request.PathBase);
            return rootUrl;
        }
    }
}
