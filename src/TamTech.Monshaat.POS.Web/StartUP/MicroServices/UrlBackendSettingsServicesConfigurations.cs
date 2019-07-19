using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Models.Shared;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Attributes.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Biography.settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Contact.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Directory.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Menus.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Pages.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Pos.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Regions.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Sectors.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Settings.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Sliders.Settings;    
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Status.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Types.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Utilities.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Values.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Vendor.Settings;
using TamTech.Monshaat.POS.Web.Services.Identity.Settings;

namespace TamTech.Monshaat.POS.Web.StartUP.MicroServices
{
    public static class BackendAPIsSettingsConfigurations
    {
        public static void MicroServices_AddBackendAPIsSettingsConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton((serviceExtension) =>
            {
                return configuration.GetSection(AppSettings.BackendApiSettings)
                                                                  .Get<BackendApiSettingsModel>();
            });

            services.AddScoped<IContactUsTypeApiSettings, TypeApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new TypeApiSettings(settings, BaseAPISettings.CUTypesController);
            });

            services.AddScoped<IPOSTypeApiSettings, TypeApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new TypeApiSettings(settings, BaseAPISettings.POSTypesController);
            });

            services.AddScoped<IPOSSectorApiSettings, SectorApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new SectorApiSettings(settings, BaseAPISettings.POSSectorsController);
            });

            services.AddScoped<IPOSAttributeApiSettings, AttributeApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new AttributeApiSettings(settings, BaseAPISettings.POSAttributesController);
            });

            services.AddScoped<IPOSValueApiSettings, ValueApiSettings>((serviceExtension) =>
           {
               BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
               return new ValueApiSettings(settings, BaseAPISettings.POSValuesController);
           });

            services.AddScoped<IContactUsRegionApiSettings, RegionApiSettings>((serviceExtension) =>
           {
               BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
               return new RegionApiSettings(settings, BaseAPISettings.CURegionsController);
           });


            services.AddScoped<IPosAdminApiSettings, PosAdminApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new PosAdminApiSettings(settings, BaseAPISettings.POSController);
            });


            services.AddScoped<IPosApiSettings, PosApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new PosApiSettings(settings, BaseAPISettings.POSofVendorController);
            });


            services.AddScoped<IDirectoryApiSettings, DirectoryApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new DirectoryApiSettings(settings, BaseAPISettings.DirectoryController);
            });


            services.AddScoped<IContactUsApiSettings, ContactUsApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new ContactUsApiSettings(settings, BaseAPISettings.ContactUsController);
            });


            services.AddScoped<IVendorAdminApiSettings, VendorAdminApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new VendorAdminApiSettings(settings, BaseAPISettings.VendorsController);
            });


            services.AddScoped<IVendorApiSettings, VendorApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new VendorApiSettings(settings, BaseAPISettings.VendorsController);
            });


            services.AddScoped<IStatisticsApiSettings, StatisticsApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new StatisticsApiSettings(settings, BaseAPISettings.StatisticsController);
            });


            services.AddScoped<ICCUApiSettings, CCUServiceSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new CCUServiceSettings(settings, BaseAPISettings.COmmonContentUtilitiesController);
            });


            services.AddScoped<IPosStatusApiSettings, StatusApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new StatusApiSettings(settings, BaseAPISettings.POSStatus);
            });

            services.AddScoped<IVendorStatusApiSettings, StatusApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new StatusApiSettings(settings, BaseAPISettings.VendorStatus);
            });

            services.AddScoped<IContactUsStatusApiSettings, StatusApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new StatusApiSettings(settings, BaseAPISettings.CSStatus);
            });

            services.AddScoped<IBiographyApiSettings, BiographyApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new BiographyApiSettings(settings, BaseAPISettings.BiographiesController);
            });

            services.AddScoped<ISettingsApiSettings, SettingsApiSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                return new SettingsApiSettings(settings, BaseAPISettings.SettingsController);
            });

            services.AddScoped<IMenuApiSettings, MenuApiSettings>((serviceExtension) =>
           {
               BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
               return new MenuApiSettings(settings, BaseAPISettings.MenusController);
           });

            services.AddScoped<IMenuItemApiSettings, MenuItemApiSettings>((serviceExtension) =>
           {
               BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
               return new MenuItemApiSettings(settings, BaseAPISettings.MenuItemsController);
           });


            services.AddScoped<ISliderApiSettings, SliderApiSettings>((serviceExtension) =>
           {
               BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
               return new SliderApiSettings(settings, BaseAPISettings.SlidersController);
           });

            services.AddScoped<ISliderItemApiSettings, SliderItemApiSettings>((serviceExtension) =>
           {
               BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
               return new SliderItemApiSettings(settings, BaseAPISettings.SliderItemsController);
           });

            services.AddScoped<IPagesApiSettings, PagesApiSettings>((serviceExtension) =>
           {
               BackendApiSettingsModel settings = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
               return new PagesApiSettings(settings, BaseAPISettings.PagesController);
           });

            services.AddScoped<IIdentityBackendSettings>((serviceExtension) =>
            {
                BackendApiSettingsModel settingsService = serviceExtension.GetRequiredService<BackendApiSettingsModel>();
                BackendApiSettingsModel settings = new BackendApiSettingsModel
                {
                    Url = settingsService.IDS4Url, 
                    ClientId = settingsService.ClientId, 
                    ClientSecret = settingsService.ClientSecret, 
                    ClientScope = settingsService.ClientScope, 
                };      
                return new IdentityBackendSettings(settings);
            });     
        }
    }
}
