using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using TamTech.ContentService.Dtos.Product;
using TamTech.ContentService.Validators;
using TamTech.ContentService.Services.Menus.Dtos;
using TamTech.ContentService.Services.Dtos;
using TamTech.ContentService.Services.Galleries.Dtos;
using TamTech.ContentService.Services.Services.Validators;
using TamTech.ContentService.Services.Menus.Validators;
using TamTech.ContentService.Services.Galleries.Validators;
using TamTech.Monshaat.POS.Web.Models.VMs.Portal.Pos;

namespace TamTech.Monshaat.POS.Web.StartUP
{
    public static class FluentValidationConfigurations
    {
        public static void AddFluentValidationConfigurations(this IServiceCollection services)
        {

            services.AddTransient<IValidator<PosFormVm>, PosFormVmValidator>();
        }

    }
}
