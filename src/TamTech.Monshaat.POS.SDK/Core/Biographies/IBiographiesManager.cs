using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.Biography;

namespace TamTech.Monshaat.POS.Web.SDK.Core.Biographies
{
    public interface IBiographiesManager
    {
        Task<BiographyInfoVm> GetInfoAsync();

        Task ReloadInfoAsync();
    }
}
