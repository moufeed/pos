using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class LocalizationConfigurations
    {
        public static void AddLocalizationConfigurations(this IServiceCollection services)
        {

            //services.AddLocalization(options =>
            //{
            //    // We will put our translations in a folder called Resources
            //    options.ResourcesPath = "Resources";
            //});


        }
    }
}
