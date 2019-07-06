using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.Services.APIsServices;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Attributes.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Sectors.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Types.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Values.Settings;

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
                return new ValueApiSettings(BaseAPISettings.POSAttributesController);
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
