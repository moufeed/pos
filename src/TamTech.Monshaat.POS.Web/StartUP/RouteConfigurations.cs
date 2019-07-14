using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Core.Cultures;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class RouteConfigurations
    {
        public static void UseMvcAndRoute(this IApplicationBuilder app, IConfiguration configuration, RequestLocalizationOptions localizationOptions, bool DisplayArea = false)
        {
            string defaultArea  = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                            .GetSection(AppSettings.Routing_DefaultArea).Get<string>() ;
                                                       



            app.UseRouter(routes =>
            {
                routes.MapMiddlewareRoute("{culture=" + CultureConstants.DefaultCulture.Culture + "}/{*mvcRoute}", subApp =>
                {
                    subApp.UseRequestLocalization(localizationOptions);
                    subApp.UseMvc(mvcRoutes =>
                    {


                        mvcRoutes.MapRoute(
                            name: "Search",
                                           template: "{culture}/{area}/Directory/search/{**slug}",
                                           defaults: new
                                           {
                                               culture = CultureConstants.DefaultCulture.Culture,
                                               area = defaultArea,
                                               controller = "Directory",
                                               action = "Search"
                                           },
                                            constraints: new { culture = CultureConstants.Constraint }
                               );

                        mvcRoutes.MapRoute(
                             name: "Directory",
                                            template: "{culture}/{area}/Directory/{slug?}",
                                            defaults: new
                                            {
                                                culture = CultureConstants.DefaultCulture.Culture,
                                                area = defaultArea,
                                                controller = "Directory",
                                                action = "Index"
                                            },
                                             constraints: new { culture = CultureConstants.Constraint }
                                );

                        mvcRoutes.MapRoute(
                            name: "default",
                            template: "{culture}/{area}/{controller}/{action}/{*slug}",
                            defaults: new
                            {
                                culture = CultureConstants.DefaultCulture.Culture,
                                area = defaultArea,
                                controller = "Home",
                                action = "index"
                            },
                            constraints: new { culture = CultureConstants.Constraint }
                        );

                        /*
                        mvcRoutes.MapRoute(
                            name: "CreatePOS",
                                           template: "{culture}/{area}/{controller}/pos/create",
                                           defaults: new
                                           {
                                               culture = CultureConstants.DefaultCulture.Culture,
                                               area = routingSettings.DefaultArea,
                                               controller = "Vendor",
                                               action = "CreatePOS"
                                           },
                                            constraints: new { culture = CultureConstants.Constraint }
                               );

                        mvcRoutes.MapRoute(
                            name: "EditPOS",
                                           template: "{culture}/{area}/{controller}/pos/edit",
                                           defaults: new
                                           {
                                               culture = CultureConstants.DefaultCulture.Culture,
                                               area = routingSettings.DefaultArea,
                                               controller = "Vendor",
                                               action = "EditPos"
                                           },
                                            constraints: new { culture = CultureConstants.Constraint }
                               );


    */

                    });
                });

            });
        }
    }
    
}   