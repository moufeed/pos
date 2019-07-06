using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Biographies.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Biographies
{
    public interface IBiographyService
    {
        Task<IRequestProviderResult<List<BiographyDto>>> GetByGroupIdAsync(int groupId, string lang);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateBiographyModel model);

        Task<IRequestProviderResult<List<BiographyDto>>> GetAllAsync();
    }
}
