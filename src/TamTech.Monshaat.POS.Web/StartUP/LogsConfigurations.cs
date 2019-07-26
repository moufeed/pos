using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System.Collections.Generic;
using TamTech.Monshaat.POS.SDK.Models.Settings;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class LogsConfigurations
    {
        public static  void AddLogsConfigurations(this IServiceCollection services)
        {
               
        }

        public static void UseLogsConfigurations(this IApplicationBuilder app, IConfiguration configuration ,ILoggerFactory loggerFactory)
        {
            List<SeriLogSettings> settings = configuration.GetSection(AppSettings.Logging)  
                                                               .GetSection(AppSettings.SeriLog)
                                                               .Get<List<SeriLogSettings>>();
            if(settings!= null)

                foreach (var item in settings)
                {
                    loggerFactory.AddFile(
                        item.PathFormat,
                        GetLogLevel(item.MinimumLevel),
                        null,
                        false,
                        item.FileSizeLimitBytes); 
                }      
        }


        public static LogLevel GetLogLevel(string level)
        {
            switch(level)
            {
                default:
                case "Error":
                    return LogLevel.Error;  
                case "None":
                    return LogLevel.None;  
                case "Warning":
                    return LogLevel.Warning;  
                case "Trace":
                    return LogLevel.Trace;  
                case "Information":
                    return LogLevel.Information;   
                case "Debug":
                    return LogLevel.Debug;         
                case "Critical":
                    return LogLevel.Critical;
            }
        }
       
    }

     
}
