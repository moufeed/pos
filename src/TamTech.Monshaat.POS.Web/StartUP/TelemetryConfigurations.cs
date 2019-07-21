using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq; 
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry; 

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class TelemetryConfigurations
    {
        public static void AddTelemetryConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            if (!services.Any(s => s.ServiceType == typeof(ITelemetryService)))
            { 
                services.AddTransient<ITelemetryService, TelemetryService> ();
            }
        }

    }
}
