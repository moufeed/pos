using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTechSDK.Web.Extensions.remove
{
    public class HttpContextExtension
    {
        HttpContext _httpContext;
        public HttpContextExtension(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }

        public Uri GetAbsoluteUri()
        {
            var request = _httpContext.Request;
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = request.Scheme;
            uriBuilder.Host = request.Host.Host;
            uriBuilder.Path = request.Path.ToString();
            uriBuilder.Query = request.QueryString.ToString();
            return uriBuilder.Uri;
        }

        public Uri GetBaseUrl()
        {
            var request = _httpContext.Request;
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = request.Scheme;
            uriBuilder.Host = request.Host.Host;
            return uriBuilder.Uri;
        }

    }
}




