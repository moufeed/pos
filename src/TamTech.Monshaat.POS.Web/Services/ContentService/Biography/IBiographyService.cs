using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Biography.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Biography
{
    public interface IBiographyService
    {
        Task<List<BiographyDto>> GetByGroupIdAsync(int groupId, string lang);

        Task<IRequestProviderResult<bool>> EditAsync(UpdateBiographyModel model);

        Task<List<BiographyDto>> GetAllAsync();
    }
}
