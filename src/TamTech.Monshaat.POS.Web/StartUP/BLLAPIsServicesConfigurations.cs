using Microsoft.Extensions.DependencyInjection; 
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Attributes;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Attributes.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Biography;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Biography.settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Contact;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Contact.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Directory;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Directory.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Pos;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Pos.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Regions;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Regions.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Sectors;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Sectors.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Settings.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Status;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Status.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Types;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Types.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Utilities;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Utilities.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Values;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Values.Settings;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Vendor;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Vendor.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.Services.ContentService.Biographies;
using TamTech.Monshaat.POS.Web.Services.ContentService.ContactUs;
using TamTech.Monshaat.POS.Web.Services.ContentService.ContentCommonUtilities;
using TamTech.Monshaat.POS.Web.Services.ContentService.Regions;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Statistics;
using TamTech.Monshaat.POS.Web.Services.ContentService.Status;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.Services.ContentService.Values;
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors;
using TamTech.Monshaat.POS.Web.Services.POSs;
using TamTech.Monshaat.POS.Web.Services.POSs.Directory;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class BLLAPIsServicesConfigurations
    {
        public static void _AddBusinessLogicAPIsServicesConfigurations(this IServiceCollection services)
        {
            /*
            #region Contents Service 
             
            services.AddScoped<IMenusServices, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Menus.DirectMenusServices>();
                services.AddTransient<IPageService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Pages.DirectPagesService>();
             services.AddTransient<ICCUServices, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Content.DirectContentService>();
            services.AddTransient<ISlidersServices, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Sliders.DirectSlidersService>();
              services.AddTransient<IContactService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Contact.DirectContactService>();
            services.AddTransient<IBiographyService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Biography.DirectBiographyService>();
            services.AddTransient<ISettingService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Settings.DirectSettingService>();



          
          

            services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Status.IContactUsStatusService>((serviceExtension) =>
            {
                var backendService = serviceExtension.GetService<TamTech.ContentService.Services.Statuses.IContactStatusService>();
                return new TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Status.DirectSatusService(backendService);
            });

            services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Status.IPosStatusService>((serviceExtension) =>
            {
                var backendService = serviceExtension.GetService<TamTech.ContentService.Services.Statuses.IPOSStatusService>();
                return new TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Status.DirectSatusService(backendService);
            });

            services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Status.IVendorStatusService>((serviceExtension) =>
            {
                var backendService = serviceExtension.GetService<TamTech.ContentService.Services.Statuses.IVendorStatusService>();
                return new TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Status.DirectSatusService(backendService);
            });


            #endregion

            /*
            #region Pos Services
            services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Statistics.IStatisticsService, Web.DirectBackendServices.UtilitiesServices.DirectStatisticsService>();

              services.AddTransient<TamTech.Monshaat.POS.Web.Services.POSs.Directory.IDirectoryServices, Web.DirectBackendServices.PosServices.Directory.DirectDirectoryService>();
            services.AddTransient<TamTech.Monshaat.POS.Web.Services.POSs.IPOSAdminServeice, Web.DirectBackendServices.PosServices.Pos.DirectAdminPosServices>();
            services.AddTransient<TamTech.Monshaat.POS.Web.Services.POSs.IPOSService, Web.DirectBackendServices.PosServices.Pos.DirectPosService>();
            services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.IVendorAdminServices, Web.DirectBackendServices.VendorService.DirectAdminVendorService>();
            services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.IVendorService, Web.DirectBackendServices.VendorService.DirectVendorService>();
            #endregion
            
            services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Regions.IRegionService, Web.DirectBackendServices.RegionsServices.DirectRegionsServices>();



            */
          

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
            
 
            /* 
             
           


            #region Upload Service 

            services.AddTransient<IUploadService, TamTech.Monshaat.POS.Web.DirectBackendServices.UploadService.DirectFileStorageService>();

            #endregion

            #region Email Service 

            services.AddTransient<IEmailSenderService, TamTech.Monshaat.POS.Web.DirectBackendServices.EmailServices.DirectEmailServices>();

            #endregion

            #region Identity Service 

            services.AddTransient<IAuthService, TamTech.Monshaat.POS.Web.DirectBackendServices.IdentityService.DirectAuthService>();
            services.AddTransient<IUsersManagerService, TamTech.Monshaat.POS.Web.DirectBackendServices.IdentityService.UsersMenager.DirectUserMenagerServices>();
            services.AddTransient<IRolesService, TamTech.Monshaat.POS.Web.DirectBackendServices.IdentityService.RolesService.DirectRolesService>();


            #endregion

            */
        }
    }
}
