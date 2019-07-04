using Microsoft.Extensions.DependencyInjection;
using TamTech.ContentService.Services.Sections;
using TamTechSDK.Common.Services.ContentService;
using TamTechSDK.Common.Services.ContentService.Biography;
using TamTechSDK.Common.Services.ContentService.Brands;
using TamTechSDK.Common.Services.ContentService.Categories;
using TamTechSDK.Common.Services.ContentService.Contact;
using TamTechSDK.Common.Services.ContentService.Galleries;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Pages;
using TamTechSDK.Common.Services.ContentService.Posts;
using TamTechSDK.Common.Services.ContentService.Products;

using TamTechSDK.Common.Services.ContentService.Reviews;
using TamTechSDK.Common.Services.ContentService.Sections;
using TamTechSDK.Common.Services.ContentService.Services;
using TamTechSDK.Common.Services.ContentService.Settings;
using TamTechSDK.Common.Services.ContentService.Sliders;
using TamTechSDK.Common.Services.ContentService.Testimonials;
using TamTechSDK.Common.Services.Email;
using TamTechSDK.Common.Services.Identity;
using TamTechSDK.Common.Services.Upload;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class BLLDirectBackendServicesConfigurations
    {
        public static void _AddBusinessLogicDirectBackendServicesConfigurations(this IServiceCollection services)
        {
            #region Contents Service 

            services.AddScoped<IMenusServices, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Menus.DirectMenusServices>();
            services.AddTransient<ICategoriesServices, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Categories.DirectCategoriesServices>();
            services.AddTransient<IProductsManagerService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Products.DirectProductsManagerService>();
            // services.AddTransient<IProductsService, Web.DirectBackendServices.ContentServices.Products.DirectProductsService> ();
            services.AddTransient<IBrandsServices, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Brands.DirectBrandsServices>();
            services.AddTransient<IPageService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Pages.DirectPagesService>();
            services.AddTransient<IReviewsServices, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Reviews.DirectReviewsServices>();
            services.AddTransient<IServicesService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Services.DirectServicesService>();
            services.AddTransient<IContentServices, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Content.DirectContentService>();
            services.AddTransient<ISlidersServices, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Sliders.DirectSlidersService>();
            services.AddTransient<IGalleriesService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Galleries.DirectGalleriesService>();
            services.AddTransient<IPostsService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Posts.DirectPostsService>();
            services.AddTransient<ISectionsService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Sections.DirectSectionsService>();
            services.AddTransient<TamTechSDK.Common.Services.ContentService.Request.IRequestService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Request.DirectRequestService>();
            services.AddTransient<TamTechSDK.Common.Services.Status.IRequestStatusService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Status.DirectSatusService>();
            services.AddTransient<TamTechSDK.Common.Services.ContentService.City.ICityService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.City.DirectCityService>();
            services.AddTransient<ITestimonialsServices, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Testimonials.DirectTestimonialsServices>();
            services.AddTransient<IContactService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Contact.DirectContactService>();
            services.AddTransient<IBiographyService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Biography.DirectBiographyService>();
            services.AddTransient<ISettingService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Settings.DirectSettingService>();



            // services.AddTransient<TamTechSDK.Common.Services.Status.IRequestStatusService, TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Status.DirectSatusService>();

            services.AddTransient<TamTechSDK.Common.Services.Status.IRequestStatusService>((serviceExtension) =>
            {
                var backendService = serviceExtension.GetService<TamTech.ContentService.Services.Statuses.IRequestStatusService>();
                return new TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Status.DirectSatusService(backendService);
            });


            services.AddTransient<TamTechSDK.Common.Services.Status.IContactStatusService>((serviceExtension) =>
            {
                var backendService = serviceExtension.GetService<TamTech.ContentService.Services.Statuses.IContactStatusService>();
                return new TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Status.DirectSatusService(backendService);
            });

            services.AddTransient<TamTechSDK.Common.Services.Status.IPosStatusService>((serviceExtension) =>
            {
                var backendService = serviceExtension.GetService<TamTech.ContentService.Services.Statuses.IPOSStatusService>();
                return new TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Status.DirectSatusService(backendService);
            });

            services.AddTransient<TamTechSDK.Common.Services.Status.IVendorStatusService>((serviceExtension) =>
            {
                var backendService = serviceExtension.GetService<TamTech.ContentService.Services.Statuses.IVendorStatusService>();
                return new TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Status.DirectSatusService(backendService);
            });


            #endregion


            #region Pos Services
            services.AddTransient<TamTechSDK.Common.Services.Utilities.IStatisticsService, Web.DirectBackendServices.UtilitiesServices.DirectStatisticsService>();

            services.AddTransient<TamTechSDK.Common.Services.PosService.Sectors.ISectorServices, Web.DirectBackendServices.PosServices.Sectors.DirectSectorsService>();
            services.AddTransient<TamTechSDK.Common.Services.PosService.Directory.IDirectoryServices, Web.DirectBackendServices.PosServices.Directory.DirectDirectoryService>();
            services.AddTransient<TamTechSDK.Common.Services.PosService.PosService.IPOSAdminServeice, Web.DirectBackendServices.PosServices.Pos.DirectAdminPosServices>();
            services.AddTransient<TamTechSDK.Common.Services.PosService.PosService.IPOSService, Web.DirectBackendServices.PosServices.Pos.DirectPosService>();
            services.AddTransient<TamTechSDK.Common.Services.VendorsServices.IVendorAdminServices, Web.DirectBackendServices.VendorService.DirectAdminVendorService>();
            services.AddTransient<TamTechSDK.Common.Services.VendorsServices.IVendorService, Web.DirectBackendServices.VendorService.DirectVendorService>();
            #endregion

            services.AddTransient<TamTechSDK.Common.Services.Regions.IRegionService, Web.DirectBackendServices.RegionsServices.DirectRegionsServices>();




            services.AddTransient<TamTechSDK.Common.Services.TypesService.IPosTypeService>((serviceExtension) =>
            {
                var service = serviceExtension.GetService<TamTech.ContentService.Services.Types.IPOSTypeService>();
                return new Web.DirectBackendServices.TypeService.DirectTypeServices(service);
            });

            services.AddTransient<TamTechSDK.Common.Services.TypesService.IContactTypeService>((serviceExtension) =>
       {
           var service = serviceExtension.GetService<TamTech.ContentService.Services.Types.IConUsTypeService>();
           return new Web.DirectBackendServices.TypeService.DirectTypeServices(service);
       });

            services.AddTransient<TamTechSDK.Common.Services.Attributes.IPOSAttributeService>((serviceExtension) =>
            {
                var service = serviceExtension.GetService<TamTech.ContentService.Services.Attributes.IPOSAttributeService>();
                return new Web.DirectBackendServices.PosServices.Attributes.DirectAttributeService(service);
            });
            services.AddTransient<TamTechSDK.Common.Services.ValuesServices.IPosValuesService>((serviceExtension) =>
            {
                var service = serviceExtension.GetService<TamTech.ContentService.Services.Values.IPOSValueService>();
                return new Web.DirectBackendServices.ValuesServices.DirectValuesServies(service);
            });
            //  services.AddTransient<TamTechSDK.Common.Services.Attributes.IAttributeService, Web.DirectBackendServices.PosServices.Attributes.DirectAttributeService>();



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
