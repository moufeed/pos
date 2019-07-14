using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TamTech.Monshaat.POS.IdentityService.Services;

namespace TamTech.Monshaat.POS.IdentityService
{
    public static class POSIdentityServiceStartup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        public static void AddIdentityService(this IServiceCollection services)
        {





            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.Cookie.HttpOnly = true;
                        options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                        //    ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
                        options.Cookie.SameSite = SameSiteMode.Lax;
                        options.Cookie.Name = "POS.AspNetCore";
                        options.LoginPath = "/Account/Login";
                        options.LogoutPath = "/Account/Logout";
                        options.AccessDeniedPath = "/Account/AccessDenied";
                    });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
                options.HttpOnly = HttpOnlyPolicy.None;
                options.Secure = CookieSecurePolicy.None;
                //  ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
            });
            services.AddMvcCore().AddAuthorization(options =>
            {
                options.AddPolicy("Vendor", policy =>
                    policy.RequireRole("TAMCMS_Vendor"));
            }).AddJsonFormatters();

            services.AddTransient<IAuthTamService, AuthTamService>();


        }


        public static void ConfigureIdentityService(this IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCookiePolicy();
            app.UseAuthentication();


        }
    }
}
