
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Text;
using TamTech.Monshaat.POS.MCI.Services.Health;
using TamTech.Monshaat.POS.SDK.Core.Health;
using TamTech.Monshaat.POS.SDK.Models.Dtos;
using TamTech.Monshaat.POS.SDK.Models.Settings;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class HealthChecksConfigurations
    {
     
        public static void AddHealthChecksConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            

          
            services.AddHealthChecks()

                .AddCheck<BackendHealthCheck>("Backend-API",
                   failureStatus: HealthStatus.Degraded,  
                    tags: new[] { "Backend-API" })

                 //.AddCheck<BackendDBHealthCheck>("Backend-DB",
                 //  failureStatus: HealthStatus.Degraded,
                 //   tags: new[] { "Backend-DB" }) 

                 .AddCheck<MCIAuthADHealthCheck>("MCI-API-AD",
                   failureStatus: HealthStatus.Degraded,
                    tags: new[] { "MCI-API-AD" })

                 .AddCheck<MCICRHealthCheck>("MCI-API-CR",
                   failureStatus: HealthStatus.Degraded,
                    tags: new[] { "MCI-API-CR" })

                 .AddCheck<MCIEmailHealthCheck>("MCI-API-Email",
                   failureStatus: HealthStatus.Degraded,
                    tags: new[] { "MCI-API-Email" });
           
                //var __healthChecksUISettings = configuration.GetSection(AppSettings.HealthChecksUI)
                //                                                   .Get<HealthChecksUISettings>();

             
          
                  
            void GetHealthChecksSettings(HealthChecks.UI.Configuration.Settings hcSettings)
            {
                string rootUrl = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                 .GetSection(AppSettings.App_Url)
                                                               .Get<string>();
                var healthChecksUISettings =    configuration.GetSection(AppSettings.HealthChecksUI)
                                                    .Get<HealthChecksUISettings>() ;
               
                hcSettings.SetEvaluationTimeInSeconds(healthChecksUISettings.EvaluationTimeOnSeconds);
                hcSettings.SetMinimumSecondsBetweenFailureNotifications(healthChecksUISettings.MinimumSecondsBetweenFailureNotifications);
                foreach (var item in healthChecksUISettings.HealthChecks)
                {
                    if(!item.Uri.Contains("http"))
                    {
                        item.Uri = $"{rootUrl}/{item.Uri}";
                    }
                    hcSettings.AddHealthCheckEndpoint(item.Name, item.Uri);
                }
                
            }

            System.Action<HealthChecks.UI.Configuration.Settings> settings = GetHealthChecksSettings;    
            services.AddHealthChecksUI("healthchecksdb", settings);     
        }
      

        public static void UseHealthChecksConfigurations(this IApplicationBuilder app, IConfiguration configuration)
        {
            var healthChecksUISettings =  configuration.GetSection(AppSettings.HealthChecksUI)
                                                   .Get<HealthChecksUISettings>() ;

           
            app.UseHealthChecks(healthChecksUISettings.GeTUriForApp(), new HealthCheckOptions()
            {   
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
        }
    }
}
