using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamTech.Monshaat.POS.Web.Core.Enums;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sliders;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sliders.Models;

namespace TamTech.Monshaat.POS.Web.Areas.Portal.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderServices _sliderService;
        public SliderViewComponent(ISliderServices slidersServices)
        {
            _sliderService = slidersServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            try
            {
                IRequestProviderResult<SliderDto> publicMainSlider = await _sliderService.GetPublishedBySettingIdAsync((int)SettingKeysEnum.HomePageMainSlider);
                if (publicMainSlider != null && publicMainSlider.Success && publicMainSlider.Data != null)
                {
                    return View(publicMainSlider.Data);
                }

            }
            catch (Exception ex)
            {
                
            }
            return View();
        }

    }
}
