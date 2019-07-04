using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Common.Models.Settings;
using TamTech.ContentService.Data.Repositories;
using TamTech.ContentService.Data.Repositories.CosmosRepositories;
using TamTech.Monshaat.POS.Web.Core.Constants;

namespace TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService
{

    public static class CosmosRepositoriesConfigurations
    {
        public static void ContentService_AddCosmosRepositoriesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(settings => configuration.GetSection(AppSettings.DirectBackendSDKsSettings)// first step (CosmosDatabase)
                                    .GetSection(AppSettings.DirectBackendSDK_ContentService_CosmosDatabaseSettings).Get<CosmosDatabaseSettings>());
            services.AddTransient(settings => configuration.GetSection(AppSettings.DirectBackendSDKsSettings)// second step (CosmosDatabase)
                                      .GetSection(AppSettings.DirectBackendSDK_ContentService_CosmosCollectionsSettings).Get<CosmosCollectionsSettings>());
            services.AddTransient<CosmosMigration, CosmosMigration>();
            services.AddTransient<IPageRepository, CosmosPageRepository>();// third step (CosmosDatabase) 
            services.AddTransient(typeof(IRepository<>), typeof(DocumentDBRepository<>));
            services.AddTransient<IProductRepository, CosmosProductRepository>();
            services.AddTransient<ICategoryRepository, CosmosCategoryRepository>();
            services.AddTransient<IBrandRepository, CosmosBrandRepository>();
            services.AddTransient<IMenuRepository, CosmosMenuRepository>();
        }

    }
}
