using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Services.APIsServices.Sliders.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sliders;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sliders.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices.Sliders
{
    public class SliderService : BaseAPIService , ISlidersServices
    {

        #region prop
            private readonly IRequestProvider _requestProvider;
            private readonly ISliderApiSettings  _apiSettings;
        #endregion
        
        #region  ctor
        public SliderService(IRequestProvider requestProvider, ISliderApiSettings apiSettings) : base(requestProvider)
        {
            _requestProvider = requestProvider;
            _apiSettings = apiSettings;
        }
        #endregion

        public async Task<IRequestProviderResult<Guid>> CreateASync(CreateSliderDto slider)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<Guid>> CreateSliderItemASync(CreateSliderItemDto slider)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<bool>> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<bool>> DeleteSliderItemByIdAsync(SliderItemKeysDto modle)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<List<SliderDto>>> GetAllAsync(string lang)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<SliderDto>> GetByIdAsync(Guid id, string lang)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<SliderDto>> GetPublishedBySettingIdAsync(int settingId)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<SliderItemDto>> GetSliderItemByIdAsync(SliderItemKeysDto model, string lang)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<bool>> publishByIdAsync(PublishModel data)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<bool>> publishSliderItemByIdAsync(SliderItemKeysDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<bool>> UpdateAsync(UpdateSliderDto slider)
        {
            throw new NotImplementedException();
        }

        public async Task<IRequestProviderResult<bool>> UpdateSliderItemAsync(UpdateSliderItemDto slider)
        {
            throw new NotImplementedException();
        }
    }
}
