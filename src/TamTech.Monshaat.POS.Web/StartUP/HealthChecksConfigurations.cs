
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Text;
using TamTech.Monshaat.POS.SDK.Core.Health;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class HealthChecksConfigurations
    {
        public static void AddHealthChecksConfigurations(this IServiceCollection services)
        {

            services.AddHealthChecks()
                .AddCheck<BackendHealthCheck>("Backend-API" ,
                   failureStatus: HealthStatus.Degraded,
                    tags: new[] { "Backend-API" });
          //       .AddCheck("Backend-API", () =>
          //HealthCheckResult.Healthy("Backend API is OK!"), tags: new[] { "Backend-API" });


    

            services.AddHealthChecksUI();
                                               

     }

        public static void UseHealthChecksConfigurations(this IApplicationBuilder app)
        {

            app.UseHealthChecks("/health"  , new HealthCheckOptions()
            {
                // Filter out the 'Bar' health check. Only Foo and Baz execute.
               // Predicate = (check) => check.Tags.Contains("Backend-API")

                ResultStatusCodes =
                  {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
                  }  ,

                 ResponseWriter = async (context, report) =>
                 {
                     context.Response.ContentType = "application/json; charset=utf-8";
                     var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(report));
                     await context.Response.Body.WriteAsync(bytes);
                 }
            });
                 
            app.UseHealthChecksUI();
            //app.UseHealthChecksUI();
            //app.UseHealthChecks("/health", new HealthCheckOptions
            //{
            //    ResponseWriter = async (context, report) =>
            //    {
            //        context.Response.ContentType = "application/json; charset=utf-8";
            //        var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(report));
            //        await context.Response.Body.WriteAsync(bytes);
            //    }
            //});

            //app.UseHealthChecks("/health");


        }
    }
}
