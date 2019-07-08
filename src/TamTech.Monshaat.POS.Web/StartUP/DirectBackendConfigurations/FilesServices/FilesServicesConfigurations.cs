using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTechBackendSDK.FileStorageService.Services;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTechBackendSDK.Common.Services.ApplicationInsightsTelemetry;
using TamTechBackendSDK.Common.Services.ApplicationInsightsTelemetry.Settings;
using System.Linq;
using FluentValidation;
using TamTech.Monshaat.POS.UploadService.Validators;
using TamTech.Monshaat.POS.UploadService.Services;
using TamTech.Monshaat.POS.UploadService.Configurations; 
using TamTech.CasAuctions.TamTech.Monshaat.POS.UploadService.Models;
using Microsoft.AspNetCore.Builder;

namespace TamTech.Monshaat.POS.Web.AppStartup.DirectBackEndServices.FilesServices
{
    public static class FilesServicesConfigurations
    {
        public static void DirectBackendServices_AddFilesServicesConfigurationsConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationInsightsTelemetry(configuration.GetSection(AppSettings.WebApplicationSettings)
                                                                  .GetSection(AppSettings.WebApplication_ApplicationInsights)
                                                                  .Get<TelemetryClientSettings>().InstrumentationKey);
            if (!services.Any(s => s.ServiceType == typeof(ITelemetryClientService)))
            {
                services.AddTransient<ITelemetryClientService, TelemetryClientService>((serviceExtension) =>
                {
                    IHttpContextAccessor httpContextAccessor = serviceExtension.GetRequiredService<IHttpContextAccessor>();
                    TelemetryClientSettings settings = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                    .GetSection(AppSettings.WebApplication_ApplicationInsights)
                                                    .Get<TelemetryClientSettings>();
                    return new TelemetryClientService(httpContextAccessor, settings);
                });
            }
            services.AddScoped<TamTechBackendSDK.FileStorageService.Services.Configurations.AppSetting.IWebApplicationSettingsService,
               TamTechBackendSDK.FileStorageService.Services.Configurations.AppSetting.WebApplicationSettingsService>((serviceExtension) =>
               {
                   string filesTypes = $"{AppSettings.DirectBackendSDKsSettings}:{ AppSettings.DirectBackendSDK_UploadService_FilesTypes}";
                   string settings = $"{AppSettings.DirectBackendSDKsSettings}:{ AppSettings.DirectBackendSDK_UploadService_Settings}";
                   return new TamTechBackendSDK.FileStorageService.Services.Configurations.AppSetting.WebApplicationSettingsService
                                   (configuration, filesTypes, settings);

               });


            services.AddTransient<IUploadService, UploadToLocal>(serviceProvider =>
                                  {
                                      var environment = serviceProvider.GetRequiredService<IHostingEnvironment>();
                                      var settings = serviceProvider.GetRequiredService<TamTechBackendSDK.FileStorageService.Services.Configurations.AppSetting.IWebApplicationSettingsService>();
                                      var telemetry = serviceProvider.GetRequiredService<ITelemetryClientService>();

                                      return new UploadToLocal(settings, telemetry, environment);
                                  });
        }





        public static void AddUploadService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IValidator<UploadModelDTO>, UploadModelValidator>();
            services.AddTransient<IUploadService, UploadToLocal>();
            services.AddTransient<IUploadSettingsConfigurations, UploadSettingsConfigurations>();
            services.AddTransient<InitializationManager>();
        }


        public static void UseUploadInitializationManager(this IApplicationBuilder app, IConfiguration Configuration)
        {
            var uploadManager = app.ApplicationServices.GetService<InitializationManager>();
            uploadManager.InitializeAsync().Wait();
            FilesHelper.FileBaseUrl = InitializationManager.UploadInfo.AbsoluteUris[0];
            FilesHelper.FileType = InitializationManager.UploadInfo.Types[0];
            InitializationManager.UploadInfo = null;
        }
    }
}
