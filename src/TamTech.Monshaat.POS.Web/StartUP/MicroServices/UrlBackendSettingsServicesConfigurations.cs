using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Status;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Status.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Types.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Utilities.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Values.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Vendor.Settings;  
using TamTech.Monshaat.POS.Web.Services.Identity.Settings;

namespace TamTech.Monshaat.POS.Web.StartUP.MicroServices
{ 
     public static class  BackendAPIsSettingsConfigurations
    {
        public static void MicroServices_AddBackendAPIsSettingsConfigurations(this IServiceCollection services, IConfiguration configuration)
        { 

            services.AddScoped<IContactUsTypeApiSettings, TypeApiSettings>((serviceExtension) =>
            { 
                return new TypeApiSettings(BaseAPISettings.CUTypesController);
            });

             services.AddScoped<IPOSTypeApiSettings, TypeApiSettings>((serviceExtension) =>
            { 
                return new TypeApiSettings(BaseAPISettings.POSTypesController);
            });

            services.AddScoped<IPOSSectorApiSettings, SectorApiSettings>((serviceExtension) =>
            {
                return new SectorApiSettings(BaseAPISettings.POSSectorsController);
            });

            services.AddScoped<IPOSAttributeApiSettings, AttributeApiSettings>((serviceExtension) =>
            {
                return new AttributeApiSettings(BaseAPISettings.POSAttributesController);
            });

              services.AddScoped<IPOSValueApiSettings,  ValueApiSettings>((serviceExtension) =>
            {
                return new ValueApiSettings(BaseAPISettings.POSValuesController);
            });

              services.AddScoped<IContactUsRegionApiSettings,  RegionApiSettings>((serviceExtension) =>
            {
                return new RegionApiSettings(BaseAPISettings.CURegionsController);
            });


            services.AddScoped<IPosAdminApiSettings, PosAdminApiSettings>((serviceExtension) =>
            {
                return new PosAdminApiSettings(BaseAPISettings.POSController);
            });
                                                                 

            services.AddScoped<IPosApiSettings, PosApiSettings>((serviceExtension) =>
            {
                return new PosApiSettings(BaseAPISettings.POSofVendorController);
            });

                      
            services.AddScoped<IDirectoryApiSettings, DirectoryApiSettings>((serviceExtension) =>
            {
                return new DirectoryApiSettings(BaseAPISettings.DirectoryController);
            });

                        
            services.AddScoped<IContactUsApiSettings, ContactUsApiSettings>((serviceExtension) =>
            {
                return new ContactUsApiSettings(BaseAPISettings.ContactUsController);
            });
                  
                        
            services.AddScoped<IVendorAdminApiSettings, VendorAdminApiSettings>((serviceExtension) =>
            {
                return new VendorAdminApiSettings(BaseAPISettings.VendorsController);
            });
                                             
                        
            services.AddScoped<IVendorApiSettings, VendorApiSettings>((serviceExtension) =>
            {
                return new VendorApiSettings(BaseAPISettings.VendorsController);
            });


            services.AddScoped<IStatisticsApiSettings, StatisticsApiSettings>((serviceExtension) =>
            {
                return new StatisticsApiSettings(BaseAPISettings.StatisticsController);
            });


              services.AddScoped<ICCUApiSettings, CCUServiceSettings>((serviceExtension) =>
            {
                return new CCUServiceSettings(BaseAPISettings.COmmonContentUtilitiesController);
            });


            services.AddScoped<IPosStatusApiSettings, StatusApiSettings>((serviceExtension) =>
            {
                return new StatusApiSettings(BaseAPISettings.POSStatus);
            });

            services.AddScoped<IVendorStatusApiSettings, StatusApiSettings>((serviceExtension) =>
            {
                return new StatusApiSettings(BaseAPISettings.VendorStatus);
            });

            services.AddScoped<IContactUsStatusApiSettings, StatusApiSettings>((serviceExtension) =>
            {
                return new StatusApiSettings(BaseAPISettings.CSStatus);
            });

             services.AddScoped<IBiographyApiSettings, BiographyApiSettings>((serviceExtension) =>
            {
                return new BiographyApiSettings(BaseAPISettings.BiographiesController);
            });

            services.AddScoped<ISettingsApiSettings, SettingsApiSettings>((serviceExtension) =>
            {
                return new SettingsApiSettings(BaseAPISettings.SettingsController);
            });  

            services.AddScoped<IMenuApiSettings,  MenuApiSettings>((serviceExtension) =>
            {
                return new MenuApiSettings(BaseAPISettings.MenusController);
            });

                 services.AddScoped<IMenuItemApiSettings,  MenuItemApiSettings>((serviceExtension) =>
            {
                return new MenuItemApiSettings(BaseAPISettings.MenuItemsController);
            });


            services.AddScoped<ISliderApiSettings,  SliderApiSettings>((serviceExtension) =>
            {
                return new SliderApiSettings(BaseAPISettings.SlidersController);
            });

            services.AddScoped<ISliderItemApiSettings,  SliderItemApiSettings>((serviceExtension) =>
            {
                return new SliderItemApiSettings(BaseAPISettings.SliderItemsController);
            });   

            services.AddScoped<IPagesApiSettings,  PagesApiSettings>((serviceExtension) =>
            {
                return new  PagesApiSettings(BaseAPISettings.PagesController);
            });   

            services.AddScoped<IIdentityBackendSettings, IdentityBackendSettings>();
            





        }
    }
}
