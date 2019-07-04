using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;
using System.Linq;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class CompressionConfigurations
    {
        public static void AddCompressionConfigurations(this IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(option =>
            {
                option.Level = CompressionLevel.Fastest;
            });

            services.AddResponseCompression(options =>
            {
                //options.Providers.Add<BrotliCompressionProvider>();

                options.EnableForHttps = true;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                    "image/svg+xml",
                    "application/font-woff2",
                    "application/x-font-ttf",
                    "font/ttf",
                    "font/eot",
                    "font/otf",
                    "font/opentype"
                });


                //options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();

            });
        }
    }
}
