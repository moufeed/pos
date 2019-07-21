using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.SDK.Core.Context
{            
    public class CustomHttpContext
    {

        public static string AppBaseUrl;
        internal static void Configure(IHttpContextAccessor contextAccessor)
        {
          var  Current = contextAccessor.HttpContext;
            AppBaseUrl =    $"{Current.Request.Scheme}://{Current.Request.Host}{Current.Request.PathBase}";
        }
    }

    public static class HttpContextExtensions
    {
        public static IApplicationBuilder UseCustomHttpContext(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var contextAccessor = scope.ServiceProvider.GetService<IHttpContextAccessor>();
            }
            var sdf = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            CustomHttpContext.Configure(sdf);
            return app;
        }
    }
}
