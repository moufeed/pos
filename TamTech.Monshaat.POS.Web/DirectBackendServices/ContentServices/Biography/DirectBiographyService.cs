using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Biography.Mapper;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Biography;
using TamTechSDK.Common.Services.ContentService.Biography.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices.ContentServices.Biography
{
    public class DirectBiographyService : BaseDirectService, IBiographyService
    {
        TamTech.ContentService.Services.Biographies.IBiographyService _BiographyService;


        public DirectBiographyService(TamTech.ContentService.Services.Biographies.IBiographyService BiographyService)
        {
            _BiographyService = BiographyService;
        }
        public async Task<IRequestProviderResult<bool>> EditAsync(UpdateBiographyModel model)
        {
            var request = await _BiographyService.EditAsync(model.MapToBackUpdateBiographyModel());
            return MapRequestProviderResult(request);
        }

        public async Task<List<BiographyDto>> GetByGroupIdAsync(int groupId, string lang)
        {
            var request = await _BiographyService.GetByGroupIdAsync(groupId, lang);
            return request?.Select(m => m.MapToFrontBiographyDto()).ToList();
        }

        public async Task<List<BiographyDto>> GetAllAsync()
        {
            var request = await _BiographyService.GetAllAsync();
            return request?.Select(m => m.MapToFrontBiographyDto()).ToList();
        }
    }
}
