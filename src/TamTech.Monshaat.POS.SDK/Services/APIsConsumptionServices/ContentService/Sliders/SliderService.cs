using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Sliders.Settings;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sliders;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sliders.Models;

namespace TamTech.Monshaat.POS.Web.Services.APIsConsumptionServices.Sliders
{
    public class SliderService : BaseAPIService , ISliderServices
    {

        #region prop
            private readonly IRequestProvider _requestProvider;
            private readonly ISliderApiSettings  _sliderApiSettings;
            private readonly ISliderItemApiSettings _sliderItemApiSettings;
        #endregion
        
        #region  ctor
        public SliderService(IRequestProvider requestProvider, ISliderApiSettings apiSettings, ISliderItemApiSettings  sliderItemApiSettings) : base(requestProvider)
        {
            _requestProvider = requestProvider;
            _sliderApiSettings = apiSettings;
            _sliderItemApiSettings = sliderItemApiSettings;
        }
        #endregion

              

        #region  {Slider}

        #region Public  
        public async Task<IRequestProviderResult<SliderDto>> GetPublishedBySettingIdAsync(int settingId)
        {
            return await _requestProvider.GetAsync<SliderDto, List<object>>(_sliderApiSettings.GetPublishedBySettingIdEndpoint, new List<object> { settingId }, PassParamsBy.Route);
        }
        #endregion

        #region  Get       
        public async Task<IRequestProviderResult<List<SliderDto>>> GetAllAsync(string lang)
        {
            return await _requestProvider.GetAsync<List<SliderDto>, List<object>>(_sliderApiSettings.GetAllEndpoint, new List<object> { lang }, PassParamsBy.Route);
        }

        public async Task<IRequestProviderResult<SliderDto>> GetByIdAsync(Guid id, string lang)
        {
            return await _requestProvider.GetAsync<SliderDto, List<object>>(_sliderApiSettings.GetByIdEndpoint, new List<object> { id, lang }, PassParamsBy.Route);
        }
        #endregion  

        #region  GetAll / Get / Create / Edit / Delete / Publish

        public async Task<IRequestProviderResult<Guid>> CreateASync(CreateSliderDto slider)
        {
            return await _requestProvider.PostAsync<Guid, CreateSliderDto>(_sliderApiSettings.CreateEndpoint, slider);
        }

        public async Task<IRequestProviderResult<bool>> UpdateAsync(UpdateSliderDto slider)
        {
            return await _requestProvider.PostAsync<bool, UpdateSliderDto>(_sliderApiSettings.UpdateEndpoint, slider);
        }
          
        public async Task<IRequestProviderResult<bool>> publishByIdAsync(PublishModel data)
        {
            return await _requestProvider.PostAsync<bool, PublishModel>(_sliderApiSettings.publishByIdEndpoint, data);
        }

        public async Task<IRequestProviderResult<bool>> DeleteByIdAsync(Guid id)
        {
            return await _requestProvider.PostAsync<bool, DeleteModel<Guid>>(_sliderApiSettings.DeleteByIdEndpoint, new DeleteModel<Guid>(id));
        }
        #endregion
        #endregion

        #region  {SliderItem}

        #region  Get 
        public async Task<IRequestProviderResult<SliderItemDto>> GetSliderItemByIdAsync(SliderItemKeysDto model, string lang)
        {
            return await _requestProvider.GetAsync<SliderItemDto, List<object>>(_sliderItemApiSettings.GetSliderItemByIdEndpoint, new List<object> { model.Id, model.SliderId, lang }, PassParamsBy.Route);
        }

        #endregion


        #region Create / Edit / Delete / Publish     
        public async Task<IRequestProviderResult<Guid>> CreateSliderItemASync(CreateSliderItemDto slider)
        {
            return await _requestProvider.PostAsync<Guid, CreateSliderItemDto>(_sliderItemApiSettings.CreateSliderItemEndpoint, slider);
        }

        public async Task<IRequestProviderResult<bool>> UpdateSliderItemAsync(UpdateSliderItemDto slideritem)
        {
            return await _requestProvider.PostAsync<bool, UpdateSliderItemDto>(_sliderItemApiSettings.UpdateSliderItemEndpoint, slideritem);
        }

        public async Task<IRequestProviderResult<bool>> publishSliderItemByIdAsync(SliderItemKeysDto model)
        {
            return await _requestProvider.PostAsync<bool, SliderItemKeysDto>(_sliderItemApiSettings.publishSliderItemByIdEndpoint, model);
        }

        public async Task<IRequestProviderResult<bool>> DeleteSliderItemByIdAsync(SliderItemKeysDto modle)
        {
            return await _requestProvider.PostAsync<bool, SliderItemKeysDto>(_sliderItemApiSettings.DeleteSliderItemByIdEndpoint, modle);
        }



        #endregion

        #endregion

    }



}
