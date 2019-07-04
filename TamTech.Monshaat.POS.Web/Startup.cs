using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TamTech.ContentService.Core.EFCore.Contexts;
using TamTech.Monshaat.POS.Web.Services.Configurations.AppSetting.Constants;
using TamTech.Monshaat.POS.Web.Settings.Cultures;
using TamTech.Monshaat.POS.Web.StartUP;

namespace TamTech.Monshaat.POS.Web
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddLocalizationConfigurations();

            services.AddMVCConfigurations();

            services.AddCompressionConfigurations();

            services.AddFiltersConfigurations();

            services.AddAuthenticationConfigurations(Configuration);

            services.AddCommonServicesConfigurations(Configuration);

            services.AddBackendMicroservicesConfigurations(Configuration);

            services.AddBusinessLogicServicesConfigurations(Configuration);

            services.AddEFileIdentityProviderConfigurations(Configuration);

            services.AddFluentValidationConfigurations();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<POSdbContext>().Database.Migrate();
            }

            app.SeedData(env, Configuration);


            if (env.IsDevelopment())
            {
                // app.UseBrowserLink(); from web admin panel
                app.UseDeveloperExceptionPage();


            }
            else
            {
                app.UseExceptionHandler("/error/500");
                app.UseHsts();
            }




            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();



            var cachePeriod = env.IsDevelopment() ? "600" : "86400";
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                }
            });
            app.UseResponseCompression();
            app.UseStatusCodePagesWithRedirects("/error/{0}");
            app.InitializeMapper();
            app.UseAuthentication();
            bool useMicroServices = Configuration.GetSection(AppSettings.WebApplicationSettings)
                .GetSection(AppSettings.WebApplication_UseMicroServices).Get<bool>();
            if (!useMicroServices)
            {
                app.UseIdentityServer();
            }

            app.UseSettings(env, Configuration);

            app.UseResponseCompression();

            app.UseAppRouter(Configuration, new CultureManager().LocalizationOptions);


        }
    }
}
//public class RouteConfig
//{
//    public static void RegisterRoutes(RouteCollection routes)
//    {
//        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//        routes.MapRoute(
//            name: "Default",
//            url: "{controller}/{action}/{id}",
//            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
//            namespaces: new string[] { "Portal.Areas.PortalAdmin.Controllers" }
//        ).DataTokens.Add("Area", "PortalAdmin");
//    }
//}
/*
 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  Steps of Reference token  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
Actors: 
1 – Identity server. 
2 – API.		 (identity.api)
3 – Client.	(AdminPanel)

API:
In AddIdentityServerAuthentication method Add ApiSecret = "apisecret" option 

Client:
Set AccessTokenType = AccessTokenType.Reference via database.
Go to Clients table in identity server DB and set AccessTokenType  field (1) value.


Identity server: 
Go to ApiSecret table in identity server database and add new record 
{ApiResourceId = API Id (identity.api id), Type = "SharedSecret", Value = "apisecret".Sha256())}
 */
