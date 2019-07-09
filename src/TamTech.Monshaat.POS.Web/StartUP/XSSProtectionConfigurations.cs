using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System; 
using TamTech.Monshaat.POS.Web.Core.Settings.Utilities;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class XSSProtectionConfigurations
    {
        public static void UseXSSProtection(this IApplicationBuilder app, IHostingEnvironment env, IConfiguration Configuration)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
                context.Response.Headers.Add("X-Frame-Options", "DENY");
                context.Response.Headers.Add("Referrer-Policy", "no-referrer");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add(
                        "Content-Security-Policy",
                        "default-src 'self'; " +
                        "img-src * 'self'  data: https:; " +
                        "font-src 'self' use.fontawesome.com ; " +
                        "style-src 'self' 'unsafe-inline' use.fontawesome.com stackpath.bootstrapcdn.com; " +
                        "script-src 'self' 'unsafe-inline'  'unsafe-eval' ajax.googleapis.com stackpath.bootstrapcdn.com cdnjs.cloudflare.com www.google.com www.gstatic.com;" +
                        "frame-src 'self' www.google.com;" +
                        "connect-src 'self';");
                await next();
            }); 
        }
    }
}
 