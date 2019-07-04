using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.SelectList;
using TamTech.Monshaat.POS.Web.Services.Status.Models;

namespace TamTech.Monshaat.POS.Web.Services.Status
{
    public class StatusService : IRequestStatusService
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
