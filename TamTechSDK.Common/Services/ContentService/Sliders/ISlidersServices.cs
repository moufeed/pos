using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Sliders.Models;

namespace TamTechSDK.Common.Services.ContentService.Sliders
{
    public interface ISlidersServices
	{

        #region Sliders

        #region Public Slider

        //Task<IRequestProviderResult<SliderDto>> GetPublicByKeyAsync(string key);

        Task<IRequestProviderResult<SliderDto>> GetPublishedBySettingIdAsync(int settingId);

        #endregion

        #region  GetAll / Get / Create / Edit / Delete / Publish

        Task<IRequestProviderResult<List<SliderDto>>> GetAllAsync(string lang);

        Task<IRequestProviderResult<SliderDto>> GetByIdAsync(Guid id , string lang);

        Task<IRequestProviderResult<Guid>> CreateASync(CreateSliderDto slider);

        Task<IRequestProviderResult<bool>> UpdateAsync(UpdateSliderDto slider);

        Task<IRequestProviderResult<bool>> DeleteByIdAsync(Guid id);

        Task<IRequestProviderResult<bool>> publishByIdAsync(PublishDTO data);



        #endregion

        #endregion



        #region Slider Items 

        #region  Get / Create / Edit / Delete / Publish


        Task<IRequestProviderResult<SliderItemDto>> GetSliderItemByIdAsync(SliderItemKeysDto model , string lang);

        Task<IRequestProviderResult<Guid>> CreateSliderItemASync(CreateSliderItemDto slider);

        Task<IRequestProviderResult<bool>> UpdateSliderItemAsync(UpdateSliderItemDto slider);

        Task<IRequestProviderResult<bool>> publishSliderItemByIdAsync(SliderItemKeysDto model);

        Task<IRequestProviderResult<bool>> DeleteSliderItemByIdAsync(SliderItemKeysDto modle);

        #endregion

        #endregion

    }
}
