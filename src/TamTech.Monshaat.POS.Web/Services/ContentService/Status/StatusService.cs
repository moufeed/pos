using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Services.ContentService.Status.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Status
{
    public class StatusService : IStatusService
    {
         
        Task<IRequestProviderResult<List<StatusDto>>> IStatusService.GetAllAsync(string lang)
        {
            throw new NotImplementedException();
        }

        Task<IRequestProviderResult<List<SelectListItemModel>>> IStatusService.GetAllSelectListAsync(string lang)
        {
            throw new NotImplementedException();
        }
    }
}
