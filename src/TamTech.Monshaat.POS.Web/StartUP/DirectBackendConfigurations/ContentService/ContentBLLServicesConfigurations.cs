using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.ContentService.Services.Sectors;
using TamTech.ContentService.Helpers;
using TamTech.ContentService.Services;
using TamTech.ContentService.Services.Brands;
using TamTech.ContentService.Services.Categorys;
using TamTech.ContentService.Services.Cities;
using TamTech.ContentService.Services.Galleries;
using TamTech.ContentService.Services.Menus;
using TamTech.ContentService.Services.Pages;
using TamTech.ContentService.Services.Posts;
using TamTech.ContentService.Services.Products;
using TamTech.ContentService.Services.Requests;
using TamTech.ContentService.Services.Sections;
using TamTech.ContentService.Services.Services;
using TamTech.ContentService.Services.Shared;
using TamTech.ContentService.Services.Sliders;
using TamTech.ContentService.Services.Statuses;
using TamTech.ContentService.Services.Testimonials;
using TamTech.ContentService.Services.Utilities.Content;
using TamTech.ContentService.Services.ContactsUs;
using TamTech.ContentService.Data.Repositories;
using TamTechBackendSDK.Common.Services.Helpers;
using TamTech.ContentService.Enums;
using TamTech.ContentService.Services.Types;
using TamTech.ContentService.Services.Values;
using TamTech.ContentService.Services.Attributes;
using TamTech.ContentService.Services.POSs;
using TamTech.ContentService.Services.Persons;
using TamTech.ContentService.Services.Regions;
using TamTech.ContentService.Services.Statistics;
using TamTech.ContentService.Services.Biographies;
using TamTech.ContentService.Services.Settings;

namespace TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService
{
    public static class ContentBLLServicesConfigurations
    {
        public static void DirectBackendServices_ContentService_AddContentBLLServicesConfigurations(this IServiceCollection services)
        {

            services.AddScoped<IIdentityHelper, HttpContextHelper>();


            services.AddTransient<IContentUtilities, ContentUtilities>();
            services.AddTransient<PageServiceManager, PageServiceManager>();
            services.AddTransient<IPageService, PageService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<MenuServiceManager, MenuServiceManager>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<ServicesServiceManager, ServicesServiceManager>();
            services.AddTransient<IServicesModuleService, ServicesModuleService>();
            services.AddTransient<ISliderService, SliderService>();
            services.AddTransient<GalleryServiceManager, GalleryServiceManager>();
            services.AddTransient<IGalleryService, GalleryService>();
            services.AddTransient<ITestimonialService, TestimonialService>();

            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<IPostService, PostService>();

            services.AddTransient<IRequestService, RequestService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<IPOSService, POSService>();
            services.AddTransient<IPOSSearchService, POSSearchService>();
            services.AddTransient<IPOSManagerService, POSService>();
            services.AddTransient<IStatisticsService, StatisticsService>();
            services.AddTransient<IBiographyService, BiographyService>();
            services.AddTransient<ISettingService, SettingService>();


            services.AddTransient<IRegionService>((serviceExtension) =>
            {

                var helper = serviceExtension.GetService<IHelperService>();
                var identity = serviceExtension.GetService<IIdentityHelper>();
                var regionRepository = serviceExtension.GetService<IRegionRepository>();
                return new RegionService(regionRepository, helper, identity, (int)ObjectTypeEnum.ContactUs);
            });


            services.AddTransient<IVendorResponsibleManagerService>((serviceExtension) =>
            {

                var helper = serviceExtension.GetService<IHelperService>();
                var identity = serviceExtension.GetService<IIdentityHelper>();
                var personRepository = serviceExtension.GetService<IPersonRepository>();
                var vendorRepository = serviceExtension.GetService<IVendorRepository>();
                var statusRepository = serviceExtension.GetService<IStatusRepository>();
                return new VendorResponsibleService(personRepository, vendorRepository, statusRepository, helper, identity, (int)ObjectTypeEnum.POS);
            });


            services.AddTransient<IVendorResponsibleService>((serviceExtension) =>
            {

                var helper = serviceExtension.GetService<IHelperService>();
                var identity = serviceExtension.GetService<IIdentityHelper>();
                var personRepository = serviceExtension.GetService<IPersonRepository>();
                var vendorRepository = serviceExtension.GetService<IVendorRepository>();
                var statusRepository = serviceExtension.GetService<IStatusRepository>();
                return new VendorResponsibleService(personRepository, vendorRepository, statusRepository, helper, identity, (int)ObjectTypeEnum.POS);
            });


            services.AddTransient<IPOSAttributeService>((serviceExtension) =>
            {
                var repository = serviceExtension.GetService<IAttributeRepository>();
                var helper = serviceExtension.GetService<IHelperService>();
                var identity = serviceExtension.GetService<IIdentityHelper>();
                return new AttributeService(repository, helper, identity, (int)ObjectTypeEnum.POS);
            });

            services.AddTransient<IPOSValueService>((serviceExtension) =>
            {
                var repository = serviceExtension.GetService<IValueRepository>();
                var helper = serviceExtension.GetService<IHelperService>();
                var identity = serviceExtension.GetService<IIdentityHelper>();
                return new ValueService(repository, helper, identity, (int)ObjectTypeEnum.POS);
            });


            services.AddTransient<IContactUsService, ContactUsService>();

            services.AddTransient<IPOSSectorService>((serviceExtension) =>
            {
                var repository = serviceExtension.GetService<ISectorRepository>();
                var helper = serviceExtension.GetService<IHelperService>();
                var identity = serviceExtension.GetService<IIdentityHelper>();
                return new SectorService(repository, helper, identity, (int)ObjectTypeEnum.POS);
            });

            services.AddTransient<IConUsTypeService>((serviceExtension) =>
            {
                var repository = serviceExtension.GetService<ITypeRepository>();
                var helper = serviceExtension.GetService<IHelperService>();
                var identity = serviceExtension.GetService<IIdentityHelper>();
                return new TypeService(repository, helper, identity, (int)ObjectTypeEnum.ContactUs);
            });

            services.AddTransient<IPOSTypeService>((serviceExtension) =>
            {
                var repository = serviceExtension.GetService<ITypeRepository>();
                var helper = serviceExtension.GetService<IHelperService>();
                var identity = serviceExtension.GetService<IIdentityHelper>();
                return new TypeService(repository, helper, identity, (int)ObjectTypeEnum.POS);
            });



            services.AddTransient<IContactStatusService>((serviceExtension) =>
            {
                var repository = serviceExtension.GetService<IStatusRepository>();
                var identity = serviceExtension.GetService<IIdentityHelper>();
                return new StatusService(repository, identity, (int)ObjectTypeEnum.ContactUs);
            });

            services.AddTransient<IPOSStatusService>((serviceExtension) =>
            {
                var repository = serviceExtension.GetService<IStatusRepository>();
                var identity = serviceExtension.GetService<IIdentityHelper>();
                return new StatusService(repository, identity, (int)ObjectTypeEnum.POS);
            });

            services.AddTransient<IVendorStatusService>((serviceExtension) =>
            {
                var repository = serviceExtension.GetService<IStatusRepository>();
                var identity = serviceExtension.GetService<IIdentityHelper>();
                return new StatusService(repository, identity, (int)ObjectTypeEnum.Vendor);
            });
        }
    }
}
