using Microsoft.Extensions.DependencyInjection; 
using TamTech.Monshaat.POS.Web.Services.ContentService.Biographies; 
using TamTech.Monshaat.POS.Web.Services.ContentService.ContactUs; 
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.Services.ContentService.Pages;  
using TamTech.Monshaat.POS.Web.Services.ContentService.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sliders;
using TamTech.Monshaat.POS.Web.Services.ContentService.ContentCommonUtilities;
using TamTech.Monshaat.POS.Web.Services.Email;
using TamTech.Monshaat.POS.Web.Services.Identity;
using TamTech.Monshaat.POS.Web.Services.Upload;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class BLLDirectBackendServicesConfigurations
    {
        public static void _AddBusinessLogicDirectBackendServicesConfigurations(this IServiceCollection services)
        {
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


            #region Pos Services
            services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Statistics.IStatisticsService, Web.DirectBackendServices.UtilitiesServices.DirectStatisticsService>();

            services.AddTransient<TamTech.Monshaat.POS.Web.Services.POSs.Directory.IDirectoryServices, Web.DirectBackendServices.PosServices.Directory.DirectDirectoryService>();
            services.AddTransient<TamTech.Monshaat.POS.Web.Services.POSs.IPOSAdminServeice, Web.DirectBackendServices.PosServices.Pos.DirectAdminPosServices>();
            services.AddTransient<TamTech.Monshaat.POS.Web.Services.POSs.IPOSService, Web.DirectBackendServices.PosServices.Pos.DirectPosService>();
            services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.IVendorAdminServices, Web.DirectBackendServices.VendorService.DirectAdminVendorService>();
            services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.IVendorService, Web.DirectBackendServices.VendorService.DirectVendorService>();
            #endregion

             //   services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Regions.IContactRegionService>((serviceExtension) =>
             //{
             //    var service = serviceExtension.GetService<TamTech.ContentService.Services.Regions.IContactUsRegionService>();
             //    return new Web.DirectBackendServices.RegionsServices.DirectRegionsServices(service);
             //});

            //services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Sectors.IPOSSectorServices>((serviceExtension) =>
            //{
            //    var service = serviceExtension.GetService<TamTech.ContentService.Services.Sectors.IPOSSectorService>();
            //    return new Web.DirectBackendServices.PosServices.Sectors.DirectSectorsService(service);
            //});

            //services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Types.IPosTypeService>((serviceExtension) =>
            //{
            //    var service = serviceExtension.GetService<TamTech.ContentService.Services.Types.IPOSTypeService>();
            //    return new Web.DirectBackendServices.TypeService.DirectTypeServices(service);
            //});

            //services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Types.IContactTypeService>((serviceExtension) =>
            //   {
            //       var service = serviceExtension.GetService<TamTech.ContentService.Services.Types.IConUsTypeService>();
            //       return new Web.DirectBackendServices.TypeService.DirectTypeServices(service);
            //   });

            //services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Attributes.IPOSAttributeService>((serviceExtension) =>
            //{
            //    var service = serviceExtension.GetService<TamTech.ContentService.Services.Attributes.IPOSAttributeService>();
            //    return new Web.DirectBackendServices.PosServices.Attributes.DirectAttributeService(service);
            //});
            //services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Values.IPosValuesService>((serviceExtension) =>
            //{
            //    var service = serviceExtension.GetService<TamTech.ContentService.Services.Values.IPOSValueService>();
            //    return new Web.DirectBackendServices.ValuesServices.DirectValuesServies(service);
            //});
            //  services.AddTransient<TamTech.Monshaat.POS.Web.Services.ContentService.Attributes.IAttributeService, Web.DirectBackendServices.PosServices.Attributes.DirectAttributeService>();



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


        }
    }
}
