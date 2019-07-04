using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.Web.Services.Configurations.AppSetting.Constants;
using TamTech.ContentService.Data;
using TamTech.ContentService.Data.Repositories.CosmosRepositories;
using TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService;
using Microsoft.AspNetCore.Hosting;

namespace TamTech.Monshaat.POS.Web.StartUP.DirectBackendConfigurations.ContentService
{
    public static class MigrateDbConfigurations_ContentService
    {
        public static void UseDataMigrationsOfContentService(this IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration)
        {
            var dbType = configuration.GetSection(AppSettings.DirectBackendSDKsSettings)
                                      .GetSection(AppSettings.DirectBackendSDK_ContetntService_UseDatabase).Get<string>();

            switch (dbType)
            {
                case "SQLServer":

                    break;
                case "Cosmos":
                    var MigrateDatabase = configuration.GetSection(AppSettings.DirectBackendSDKsSettings)
                                                       .GetValue<bool>(AppSettings.DirectBackendSDK_ContentService_MigrateDatabase);

                    if (MigrateDatabase)
                    {

                        var cosmosMigration = app.ApplicationServices.GetService<CosmosMigration>();
                        cosmosMigration.MigrateAsync().Wait();

                        //var SeedDatabase = Configuration.GetValue<bool>("SeedDatabase");
                        //if (SeedDatabase)
                        //{
                        //    cosmosRepository.SeedAsync().Wait();
                        //}

                    }
                    break;
            }



        }
    }
}
