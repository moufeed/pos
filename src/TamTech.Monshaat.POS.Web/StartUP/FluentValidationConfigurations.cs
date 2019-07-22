using Microsoft.Extensions.DependencyInjection;
using FluentValidation;  
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Portal.Pos;

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
