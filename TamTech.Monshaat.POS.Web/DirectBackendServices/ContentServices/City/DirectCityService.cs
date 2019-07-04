using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.City.Mapper;
using TamTechSDK.Common.Models.SelectList;
using TamTechSDK.Common.Services.ContentService.City;
using TamTechSDK.Common.Services.ContentService.City.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.City
{
    public class DirectCityService : ICityService
    {
        private readonly TamTech.ContentService.Services.Cities.ICityService _cityservice;



        public DirectCityService(TamTech.ContentService.Services.Cities.ICityService cityservice)
        {
            _cityservice = cityservice;
        }

        public async Task<List<SelectListItemModel>> GetAllListExceptSoftDeletedAsync()
        {
            var result = await _cityservice.GetAllListExceptSoftDeletedAsync();

            return result != null ? result.Select(m => m.MapToFrontEndSelectListItemModel()).ToList() : new List<SelectListItemModel>();
        }

        public async Task<List<CityDto>> GetPublicListAsync()
        {
            var result = await _cityservice.GetPublicListAsync();

            return result != null ? result.Select(m => m.MapToForntEndCity()).ToList() : new List<CityDto>();
        }
    }
}
