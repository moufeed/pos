using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Services.Status.Models;

namespace TamTechSDK.Common.Services.Status
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
