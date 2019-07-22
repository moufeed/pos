using Microsoft.Extensions.DependencyInjection; 
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Attributes;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Attributes.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Biography;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Biography.settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Contact;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Contact.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Directory;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Directory.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.IdentityService;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Menus;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Pages;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Pos;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Pos.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Regions;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Regions.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Sectors;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Sectors.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Settings.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Sliders;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Status;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Status.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Types;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Types.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Utilities;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Utilities.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Values;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Values.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Vendor;
using TamTech.Monshaat.POS.Web.SDK.Services.APIsConsumptionServices.Vendor.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Biographies;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContactUs;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContentCommonUtilities;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Pages;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Regions;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Settings;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sliders;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Statistics;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Status;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Values;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Vendors;
using TamTech.Monshaat.POS.Web.SDK.Services.Identity;
using TamTech.Monshaat.POS.Web.SDK.Services.POSs;
using TamTech.Monshaat.POS.Web.SDK.Services.POSs.Directory;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class BLLAPIsServicesConfigurations
    {
        public static void AddBLLAPIsServicesConfigurations(this IServiceCollection services)
        {
            #region Identity Service       
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUsersManagerService, UsersManagerService>();
            services.AddTransient<IRolesService, RolesService>();
            #endregion

            services.AddTransient<IPosTypeService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IPOSTypeApiSettings>();
                return new TypeService(provider, apiSettings);
            });

            services.AddTransient<IContactTypeService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IContactUsTypeApiSettings>();
                return new TypeService(provider, apiSettings);
            });

            services.AddTransient<IPOSSectorServices>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IPOSSectorApiSettings>();
                return new SectorService(provider, apiSettings);
            });


            services.AddTransient<IPOSAttributeService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IPOSAttributeApiSettings>();
                return new AttributeService(provider, apiSettings);
            });


            services.AddTransient<IPosValuesService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IPOSValueApiSettings>();
                return new ValueService(provider, apiSettings);
            });


            services.AddTransient<IContactRegionService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IContactUsRegionApiSettings>();
                return new RegionService(provider, apiSettings);
            });



            services.AddTransient<IDirectoryServices>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IDirectoryApiSettings>();
                return new DirectoryService(provider, apiSettings);
            });


            services.AddTransient<IContactService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IContactUsApiSettings>();
                return new ContactService(provider, apiSettings);
            });


            services.AddTransient<IPOSAdminServeice>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IPosAdminApiSettings>();
                return new PosAdminService(provider, apiSettings);
            });

            services.AddTransient<IPOSService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IPosApiSettings>();
                return new PosService(provider, apiSettings);
            });


            services.AddTransient<IVendorAdminServices>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IVendorAdminApiSettings>();
                return new VendoradminService(provider, apiSettings);
            });


            services.AddTransient<IVendorService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IVendorApiSettings>();
                return new VendorService(provider, apiSettings);
            });



            services.AddTransient<ICCUServices>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<ICCUApiSettings>();
                return new CCUServices(provider, apiSettings);
            });


            services.AddTransient<IStatisticsService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IStatisticsApiSettings>();
                return new StatisticsService(provider, apiSettings);
            });




            services.AddTransient<IContactUsStatusService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IContactUsStatusApiSettings>();
                return new StatusService(provider, apiSettings);
            });


            services.AddTransient<IPosStatusService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IPosStatusApiSettings>();
                return new StatusService(provider, apiSettings);
            });


            services.AddTransient<IVendorStatusService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IVendorStatusApiSettings>();
                return new StatusService(provider, apiSettings);
            });

             services.AddTransient<IBiographyService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<IBiographyApiSettings>();
                return new BiographyService(provider, apiSettings);
            });

            services.AddTransient<ISettingService>((serviceExtension) =>
            {
                var provider = serviceExtension.GetService<IRequestProvider>();
                var apiSettings = serviceExtension.GetService<ISettingsApiSettings>();
                return new SettingsService(provider, apiSettings);

            });
            services.AddScoped<IMenusServices,  MenusServices>();
            services.AddTransient<IPageService,  PageService>();
            services.AddTransient<ISliderServices, SliderService>();


           

          
        }
    }
}
