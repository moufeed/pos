using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Common.Models.Settings;
using TamTech.ContentService.Core.EFCore.Contexts;
using TamTech.ContentService.Data.Repositories;
using TamTech.ContentService.Data.Repositories.EFCore;

namespace TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService
{

    public static class EFCoreRepositoriesConfigurations
    {
        public static void ContentService_AddEFCoreRepositoriesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddDbContext<ContentDbContext>(options =>
            //            options.UseSqlServer(configuration.GetConnectionString(AppSettings.DirectBackendSDK_ContentService_ContentDB)));

            services.AddDbContext<POSdbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DirectBackendSDK_ContentService_ContentDB"),
                         x => x.MigrationsHistoryTable(
                            "__CS_EFMigrationsHistory")));


            services.AddTransient<IContentUtilitiesRepository, EFCoreContentUtilitiesRepository>();
            // services.AddTransient(typeof(IRepository<>), typeof(EFCoreDBRepository<>));
            services.AddTransient<IProductRepository, EFCoreProductRepository>();
            services.AddTransient<ICategoryRepository, EFCoreCategoryRepository>();
            services.AddTransient<IBrandRepository, EFCoreBrandRepository>();
            services.AddTransient<IPageRepository, EFCorePageRepository>();
            services.AddTransient<IMenuRepository, EFCoreMenuRepository>();
            services.AddTransient<ISliderRepository, EFCoreSliderRepository>();
            services.AddTransient<IServiceRepository, EFCoreServiceRepository>();
            services.AddTransient<IGalleryRepository, EFCoreGalleryRepository>();
            services.AddTransient<ITestimonialRepository, EFCoreTestimonialRepository>();

            services.AddTransient<IPostSectionRepository, EFCorePostSectionRepository>();
            services.AddTransient<IPostRepository, EFCorePostRepository>();

            services.AddTransient<IRequestRepository, EFCoreRequestRepository>();
            services.AddTransient<ICityRepository, EFCoreCityRepository>();
            services.AddTransient<IStatusRepository, EFCoreStatusRepository>();
            services.AddTransient<IRegionRepository, EFCoreRegionRepository>();




            services.AddTransient<IAttributeRepository, EFCoreAttributeRepository>();
            services.AddTransient<IAttachmentRepository, EFCoreAttachmentRepository>();
            services.AddTransient<IPOSRepository, EFCorePOSRepository>();
            services.AddTransient<ISectorRepository, EFCoreSectorRepository>();
            services.AddTransient<ITypeRepository, EFCoreTypeRepository>();
            services.AddTransient<IValueRepository, EFCoreValueRepository>();
            services.AddTransient<IContactUsRepository, EFCoreContactUsRepository>();
            services.AddTransient<IProcessRepository, EFCoreProcessRepository>();
            services.AddTransient<IPersonRepository, EFCorePersonRepository>();
            services.AddTransient<IVendorRepository, EFCoreVendorRepository>();
            services.AddTransient<IBiographyRepository, EFCoreBiographyRepository>();
            services.AddTransient<ISettingRepository, EFCoreSettingRepository>();
        }

    }
}
