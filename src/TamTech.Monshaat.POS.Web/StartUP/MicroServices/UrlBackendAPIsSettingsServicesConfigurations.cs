using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using TamTech.Monshaat.POS.Web.SDK.Models.Shared;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Attributes.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Biography.settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Contact.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Directory.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Menus.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Pages.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Pos.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Regions.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Sectors.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Settings.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Sliders.Settings;    
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Status.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Types.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Utilities.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Values.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Vendor.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity.Settings;

namespace TamTech.Monshaat.POS.Web.StartUP.MicroServices
{
    public static class BackendAPIsSettingsConfigurations
    {
        public static void MicroServices_AddBackendAPIsSettingsConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton((serviceExtension) =>
            {
                return configuration.GetSection(AppSettings.BackendApiSettings)
                                                                  .Get<BackendApiSettings>();
            });

            services.AddScoped<IContactUsTypeApiSettings, TypeApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new TypeApiSettings(settings, BaseAPISettings.CUTypesController);
            });

            services.AddScoped<IPOSTypeApiSettings, TypeApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new TypeApiSettings(settings, BaseAPISettings.POSTypesController);
            });

            services.AddScoped<IPOSSectorApiSettings, SectorApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new SectorApiSettings(settings, BaseAPISettings.POSSectorsController);
            });

            services.AddScoped<IPOSAttributeApiSettings, AttributeApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new AttributeApiSettings(settings, BaseAPISettings.POSAttributesController);
            });

            services.AddScoped<IPOSValueApiSettings, ValueApiSettings>((serviceExtension) =>
           {
               BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
               return new ValueApiSettings(settings, BaseAPISettings.POSValuesController);
           });

            services.AddScoped<IContactUsRegionApiSettings, RegionApiSettings>((serviceExtension) =>
           {
               BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
               return new RegionApiSettings(settings, BaseAPISettings.CURegionsController);
           });


            services.AddScoped<IPosAdminApiSettings, PosAdminApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new PosAdminApiSettings(settings, BaseAPISettings.POSController);
            });


            services.AddScoped<IPosApiSettings, PosApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new PosApiSettings(settings, BaseAPISettings.POSofVendorController);
            });


            services.AddScoped<IDirectoryApiSettings, DirectoryApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new DirectoryApiSettings(settings, BaseAPISettings.DirectoryController);
            });


            services.AddScoped<IContactUsApiSettings, ContactUsApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new ContactUsApiSettings(settings, BaseAPISettings.ContactUsController);
            });


            services.AddScoped<IVendorAdminApiSettings, VendorAdminApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new VendorAdminApiSettings(settings, BaseAPISettings.VendorsController);
            });


            services.AddScoped<IVendorApiSettings, VendorApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new VendorApiSettings(settings, BaseAPISettings.VendorsController);
            });


            services.AddScoped<IStatisticsApiSettings, StatisticsApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new StatisticsApiSettings(settings, BaseAPISettings.StatisticsController);
            });


            services.AddScoped<ICCUApiSettings, CCUServiceSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new CCUServiceSettings(settings, BaseAPISettings.COmmonContentUtilitiesController);
            });


            services.AddScoped<IPosStatusApiSettings, StatusApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new StatusApiSettings(settings, BaseAPISettings.POSStatus);
            });

            services.AddScoped<IVendorStatusApiSettings, StatusApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new StatusApiSettings(settings, BaseAPISettings.VendorStatus);
            });

            services.AddScoped<IContactUsStatusApiSettings, StatusApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new StatusApiSettings(settings, BaseAPISettings.CSStatus);
            });

            services.AddScoped<IBiographyApiSettings, BiographyApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new BiographyApiSettings(settings, BaseAPISettings.BiographiesController);
            });

            services.AddScoped<ISettingsApiSettings, SettingsApiSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                return new SettingsApiSettings(settings, BaseAPISettings.SettingsController);
            });

            services.AddScoped<IMenuApiSettings, MenuApiSettings>((serviceExtension) =>
           {
               BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
               return new MenuApiSettings(settings, BaseAPISettings.MenusController);
           });

            services.AddScoped<IMenuItemApiSettings, MenuItemApiSettings>((serviceExtension) =>
           {
               BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
               return new MenuItemApiSettings(settings, BaseAPISettings.MenuItemsController);
           });


            services.AddScoped<ISliderApiSettings, SliderApiSettings>((serviceExtension) =>
           {
               BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
               return new SliderApiSettings(settings, BaseAPISettings.SlidersController);
           });

            services.AddScoped<ISliderItemApiSettings, SliderItemApiSettings>((serviceExtension) =>
           {
               BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
               return new SliderItemApiSettings(settings, BaseAPISettings.SliderItemsController);
           });

            services.AddScoped<IPagesApiSettings, PagesApiSettings>((serviceExtension) =>
           {
               BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
               return new PagesApiSettings(settings, BaseAPISettings.PagesController);
           });

            services.AddScoped<IIdentityBackendSettings>((serviceExtension) =>
            {
                BackendApiSettings settings = serviceExtension.GetRequiredService<BackendApiSettings>();
                //BackendApiSettingsModel settings = new BackendApiSettingsModel
                //{
                //    Url = settingsService.IDS4Url, 
                //    ClientId = settingsService.ClientId, 
                //    ClientSecret = settingsService.ClientSecret, 
                //    ClientScope = settingsService.ClientScope, 
                //};      
                return new IdentityBackendSettings(settings);
            });     
        }
    }
}
