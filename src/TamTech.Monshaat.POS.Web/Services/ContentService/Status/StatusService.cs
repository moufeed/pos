using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Services.ContentService.Status.Models;

namespace TamTech.Monshaat.POS.Web.Services.ContentService.Status
{
    public class StatusService : IStatusService
    {
        public Task<List<StatusDto>> GetAllAsync(string lang)
        {
            throw new NotImplementedException();
        }

        public Task<List<SelectListItemModel>> GetAllSelectListAsync(string lang)
        {
            throw new NotImplementedException();
        }
    }
}
