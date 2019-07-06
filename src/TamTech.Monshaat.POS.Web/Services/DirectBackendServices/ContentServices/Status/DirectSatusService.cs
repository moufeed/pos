using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Services.ContentService.Status;
using TamTech.Monshaat.POS.Web.Services.ContentService.Status.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Status
{
    public class DirectSatusService : BaseDirectService, IContactUsStatusService, IPosStatusService, IVendorStatusService
    {
        private TamTech.ContentService.Services.Statuses.IStatusService _statusService;


        public DirectSatusService(TamTech.ContentService.Services.Statuses.IStatusService statusService)
        {
            _statusService = statusService;
        }

        public async Task<IRequestProviderResult<List<StatusDto>>> GetAllAsync(string lang)
        {
            var result = await _statusService.GetAllAsync(lang);

            return ReturnRequestProviderResult(result != null ? result.Select(m => m.MapToFrontStatusDto()).ToList() : new List<StatusDto>());
        }

        public async Task<IRequestProviderResult<List<SelectListItemModel>>> GetAllSelectListAsync(string lang)
        {
            var result = await _statusService.GetAllSelectListAsync(lang);

            return ReturnRequestProviderResult(result != null ? result.Select(m => m.MapToFrontEndSelectListItemModel()).ToList() : new List<SelectListItemModel>());
        }



    }
}
