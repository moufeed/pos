using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using TamTech.ContentService.Core.Domain.Models;
using TamTech.ContentService.Data;

namespace TamTech.Monshaat.POS.Web.StartUP.ContentService
{
    public static class BiographiesConfigurations
    {
        public static void UseBiographies(this IApplicationBuilder app, IHostingEnvironment env, IConfiguration Configuration)
        {
            //var service =  app.ApplicationServices.GetService<TamTech.ContentService.Services.Biographies.IBiographyService>() ;
            // var migrateData = Configuration.GetSection("DirectBackendSDKsSettings").GetValue<bool>("DirectBackendSDK_ContentService_MigrateDatabase");
            // if (!migrateData) return;

            // var builder = new ConfigurationBuilder()
            //     .SetBasePath(env.ContentRootPath).AddJsonFile("DataMigrations.json", optional: true, reloadOnChange: true);

            // DataMigrationModel dataSource = builder.Build().Get<DataMigrationModel>();

            // var biographiesBuilder = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath).AddJsonFile("DataMigrations.Biographies.json", optional: true, reloadOnChange: true);

            // DataMigrationModel bio = biographiesBuilder.Build().Get<DataMigrationModel>();

            // dataSource.Biographies = bio.Biographies;
            // POSDataMigrationsManager dataMigrationManager = new POSDataMigrationsManager(dataSource, app);
            // dataMigrationManager.MigrateAsync();

        }
    }
}
