using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Services.Status;
using TamTechSDK.Common.Services.Status.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Status
{
    public class DirectSatusService : IRequestStatusService, IContactStatusService, IPosStatusService, IVendorStatusService
    {
        private TamTech.ContentService.Services.Statuses.IStatusService _statusService;


        public DirectSatusService(TamTech.ContentService.Services.Statuses.IStatusService statusService)
        {
            _statusService = statusService;
        }

        public async Task<List<StatusDto>> GetAllAsync(string lang)
        {
            var result = await _statusService.GetAllAsync(lang);

            return result != null ? result.Select(m => m.MapToFrontStatusDto()).ToList() : new List<StatusDto>();
        }

        public async Task<List<SelectListItemModel>> GetAllSelectListAsync(string lang)
        {
            var result = await _statusService.GetAllSelectListAsync(lang);

            return result != null ? result.Select(m => m.MapToFrontEndSelectListItemModel()).ToList() : new List<SelectListItemModel>();
        }



    }
}
