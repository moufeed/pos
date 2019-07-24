using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class LogsConfigurations
    {
        public static IServiceCollection AddLogsConfigurations(this IServiceCollection services)
        {
            

            return services;
        }

        public static IApplicationBuilder UseLogsConfiguration(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
          //  Log.Logger = new LoggerConfiguration()
          //// Restricts logs to: Debug, Information, Warning, Error and Fatal
          //.MinimumLevel.Debug()
          //// Logs Information, Warning, Error and Fatal to "info-logs.txt" file
          //.WriteTo.File(path: "Logs/info-logs.txt", restrictedToMinimumLevel: LogEventLevel.Information)
          //// Logs Error and Fatal to "error-logs.txt" file
          //.WriteTo.File(path: "Logs/error-logs.txt", restrictedToMinimumLevel: LogEventLevel.Error)
          //.CreateLogger();


          loggerFactory.AddFile("Logs/info-log-pos-app-{Date}.txt", LogLevel.Information);//,LogLevel.Information,null,true, 10000);
          loggerFactory.AddFile("Logs/warning---log-pos-app-{Date}.txt", LogLevel.Warning);//,LogLevel.Information,null,true, 10000);
           

            return app;
        }
    }

     
}
