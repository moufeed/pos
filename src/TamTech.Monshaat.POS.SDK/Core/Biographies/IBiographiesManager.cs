using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared.Biography;

namespace TamTech.Monshaat.POS.Web.Core.Biographies
{
    public interface IBiographiesManager
    {
        Task<BiographyInfoVm> GetInfoAsync();

        Task ReloadInfoAsync();
    }
}
