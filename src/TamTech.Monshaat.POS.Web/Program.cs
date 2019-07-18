using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus;

namespace TamTech.Monshaat.POS.Web
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                /* .UseApplicationInsights()*/
                 .UseKestrel(c => c.AddServerHeader = false)
                 .UseIISIntegration()
                 .UseStartup<Startup>();


    }
}
