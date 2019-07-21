using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Pages;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Pages.Enums;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Pages.Models;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;

namespace TamTechSDK.Web.Controllers.Portal
{


    public class PagesController : PublicBaseController
    {
        #region Props 
        IPageService _pageService;
        #endregion


        #region Ctors
        public PagesController(ITelemetryService telemetryClientService, IPageService pageService , IStringLocalizer<BaseController> localizer)
            : base(telemetryClientService , localizer)
        {
            this._pageService = pageService;
        }
        #endregion

        #region utilities
        public TResult DeserializeFromObject<TResult>(dynamic inputObject)
        {
            string serialized = JsonConvert.SerializeObject(inputObject);
            var handledResult = JsonConvert.DeserializeObject<TResult>(serialized);
            return handledResult;
        }
        #endregion

        #region Actions 

        
        [HttpGet]
        public virtual async Task<IActionResult> Index() => NotFound();
 

         
        [ActionName("v")]
        public virtual async Task<ActionResult> Details(string slug)
        {
            try
            {
                var page = await _pageService.GetPublicBySlugAsync(slug);

                if (VerifySucceed(page))
                {
                    var type = page.Data.Type == (int)PageTypeEnum.Sections ? PageTypeEnum.Sections : PageTypeEnum.Html;
                    if (type == PageTypeEnum.Html)
                    {
                        return View($"Preview_{type.ToString()}", page.Data);
                    }
                    else
                    {
                        return View($"Preview_{type.ToString()}", page.Data);
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return RedirectToNotFound(slug);

        }


        [ActionName("s")]
        public virtual async Task<ActionResult> SectionPage(Guid slug)
        {
            try
            {
                var page = await _pageService.GetPublishedSectionsPageByIdAsync(slug);
                if (VerifySucceed(page))
                {
                    return View("Preview_Sections", page.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Preview_Sections");
        }

        [ActionName("h")]
        public virtual async Task<ActionResult> HtmlPage(Guid slug)
        {
            try
            {
                var page = await _pageService.GetPublishedHtmlPageByIdAsync(slug);
                if (VerifySucceed(page))
                {
                    return View("Preview_HtmlPage", page.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Preview_HtmlPage");
        }
        #endregion
    }
}
