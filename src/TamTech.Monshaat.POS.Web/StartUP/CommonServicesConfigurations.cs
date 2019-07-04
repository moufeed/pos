using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TamTech.Monshaat.POS.Web.Core.Biographies;
using TamTech.Monshaat.POS.Web.Core.Settings.Utilities;
using TamTech.Monshaat.POS.Web.Services.Configurations.AppSetting.Constants;
using TamTechSDK.Common.Helpers.Converters;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.Helpers;
using TamTechSDK.Common.Services.Upload;
using TamTechSDK.Common.Services.Upload.FileTypes;
using TamTechSDK.Web.Services.ContentService.Menus.PublicService;
using TamTechSDK.Web.Services.Validations;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class CommonServicesConfigurations
    {
        public static void AddCommonServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationInsightsTelemetryConfigurations(configuration);


            //   services.AddScoped<IAppSettingsFile, AppSettingsFileReader>();

            services.AddSingleton<IHelperService, HelperService>();
            services.AddScoped<IStringConverters, StringConverters>();
            services.AddScoped<IExpressionValidation, ExpressionValidation>();


            // services.AddScoped<ICulturesManager, ConstantsCulturesService>();   

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //   services.AddTransient<IHelperService, HelperService>();


            services.AddScoped<IUploadManagerService, UploadManagerService>((serviceExtension) =>
            {
                List<FileTypesSettingsModel> Settings = configuration.GetSection(AppSettings.WebApplicationSettings)
                    .GetSection(AppSettings.WebApplication_FilesTypesSettings)
                    .GetSection(AppSettings.FilesTypes)
                    .Get<List<FileTypesSettingsModel>>();
                var uploadService = serviceExtension.GetRequiredService<IUploadService>();
                return new UploadManagerService(Settings, uploadService);
            });



            bool CacheMenus = configuration.GetSection(AppSettings.WebApplicationSettings)
                .GetSection(AppSettings.WebApplication_CacheMenus)
                .Get<bool>();
            if (CacheMenus)
            {
                services.AddScoped<IPortalMenusService, CashedMenusService>();
            }
            else
            {
                services.AddScoped<IPortalMenusService, WebPublicMenusService>();
            }

            services.AddScoped<IBiographiesManager, StatisCashedBiographies>();
            services.AddScoped<SettingsHelpers>();

        }
    }
}
