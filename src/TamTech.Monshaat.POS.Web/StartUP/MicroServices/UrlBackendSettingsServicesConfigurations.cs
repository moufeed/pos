using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.Services.APIsServices;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Attributes.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Biography.settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Contact.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Directory.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Pos.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Regions.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Sectors.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Settings.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Status;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Status.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Types.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Utilities.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Values.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Vendor.Settings;

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

            //services.AddScoped<IUploadBackendSettings, UploadBackendSettings>((serviceExtension) =>
            //{
            //    var url = configuration
            //    .GetSection(AppSettings.MicroServicesSettings)
            //    .GetSection(AppSettings.MicroServices_UploadService)
            //    .GetValue<string>("Url");

            //    return new UploadBackendSettings(url);
            //});


            //services.AddScoped<IIdentityBackendSettings, IdentityBackendSettings>((serviceExtension) =>
            //{
            //    var url = configuration
            //    .GetSection(AppSettings.MicroServicesSettings)
            //    .GetSection(AppSettings.MicroServices_IdentityService)
            //    .GetValue<string>("Url");

            //    return new IdentityBackendSettings(url);
            //});

            //services.AddScoped<IContentsServiceSettings, ContentsServiceSettings>((serviceExtension) =>
            //{
            //    var url = configuration
            //    .GetSection(AppSettings.MicroServicesSettings)
            //    .GetSection(AppSettings.MicroServices_ContentsService)
            //    .GetValue<string>("Url");

            //    return new ContentsServiceSettings(url);
            //});




            //services.AddScoped<IPageServiceSettings, PageServiceSettings>();
            //services.AddScoped<IProductManagerServiceSettings, ProductManagerServiceSettings>();
            //services.AddScoped<IProductServiceSettings, ProductServiceSettings>();
            //services.AddScoped<IBrandServiceSettings, BrandServiceSettings>();
            //services.AddScoped<ICategoryServiceSettings, CategoryServiceSettings>(); 
            //services.AddScoped<IMenusServicesSettings, MenusServicesSettings>();




        }
    }
}
