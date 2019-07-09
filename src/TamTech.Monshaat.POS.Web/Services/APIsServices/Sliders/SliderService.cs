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



        public async Task<IRequestProviderResult<SliderDto>> GetPublishedBySettingIdAsync(int settingId)
        {
            return await _requestProvider.GetAsync<SliderDto, List<object>>(_apiSettings.GetAllEndpoint, new List<object> { settingId }, PassParamsBy.Route);
        }


        //TODO getSliderItem
        public async Task<IRequestProviderResult<SliderItemDto>> GetSliderItemByIdAsync(SliderItemKeysDto model, string lang)
        {
            throw new NotImplementedException();
        }


        public async Task<IRequestProviderResult<Guid>> CreateASync(CreateSliderDto slider)
        {
            return await _requestProvider.PostAsync<Guid, CreateSliderDto>(_apiSettings.CreateEndpoint, slider);
        }

        public async Task<IRequestProviderResult<Guid>> CreateSliderItemASync(CreateSliderItemDto slider)
        {
            return await _requestProvider.PostAsync<Guid, CreateSliderItemDto>(_apiSettings.CreateSliderItemEndpoint, slider);
        }

        public async Task<IRequestProviderResult<bool>> DeleteByIdAsync(Guid id)
        {
            return await _requestProvider.PostAsync<bool, DeleteModel<Guid>>(_apiSettings.DeleteByIdEndpoint, new DeleteModel<Guid>(id));
        }

        public async Task<IRequestProviderResult<bool>> DeleteSliderItemByIdAsync(SliderItemKeysDto modle)
        {
            return await _requestProvider.PostAsync<bool, SliderItemKeysDto>(_apiSettings.DeleteSliderItemByIdEndpoint, modle);
        }

        public async Task<IRequestProviderResult<List<SliderDto>>> GetAllAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<SliderDto>, List<object>>(_apiSettings.GetAllEndpoint , new List<object> { lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<SliderDto>> GetByIdAsync(Guid id, string lang)
        {
            return await _requestProvider.GetAsync<SliderDto, List<object>>(_apiSettings.GetByIdEndpoint, new List<object> { id , lang }, PassParamsBy.Route);
        }

        

        public async Task<IRequestProviderResult<bool>> publishByIdAsync(PublishModel data)
        {
            return await _requestProvider.PostAsync<bool, PublishModel>(_apiSettings.publishByIdEndpoint, data);
        }

        public async Task<IRequestProviderResult<bool>> publishSliderItemByIdAsync(SliderItemKeysDto model)
        {
            return await _requestProvider.PostAsync<bool, SliderItemKeysDto>(_apiSettings.publishSliderItemByIdEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> UpdateAsync(UpdateSliderDto slider)
        {
            return await _requestProvider.PostAsync<bool, UpdateSliderDto>(_apiSettings.UpdateEndpoint, slider);
        }

        public async Task<IRequestProviderResult<bool>> UpdateSliderItemAsync(UpdateSliderItemDto slideritem)
        {
            return await _requestProvider.PostAsync<bool, UpdateSliderItemDto>(_apiSettings.UpdateSliderItemEndpoint, slideritem);
        }
    }
}
