using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Services.ContentService.City.Models;

namespace TamTechSDK.Common.Services.ContentService.City
{
    public class CityService : ICityService
    {
        public Task<List<SelectListItemModel>> GetAllListExceptSoftDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CityDto>> GetPublicListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
