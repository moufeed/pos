using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Pages;
using TamTechSDK.Common.Services.ContentService.Pages.Enums;
using TamTechSDK.Common.Services.ContentService.Pages.Models;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Portal
{


    public class PagesController : PublicBaseController
    {
        #region Props 
        IPageService _pageService;
        #endregion


        #region Ctors
        public PagesController(ITelemetryService telemetryClientService, IPageService pageService)
            : base(telemetryClientService)
        {
            this._pageService = pageService;
        }
        #endregion



        #region Actions 

        // [HttpGet("[Area]/{lang}/[Controller]/")]
        [HttpGet]
        public virtual async Task<IActionResult> Index()
        {
            return NotFound();
        }



        public TResult DeserializeFromObject<TResult>(dynamic inputObject)
        {
            string serialized = JsonConvert.SerializeObject(inputObject);
            var handledResult = JsonConvert.DeserializeObject<TResult>(serialized);
            return handledResult;
        }


        // [HttpGet("[Area]/{lang}/[Controller]/{slug}")]
        [ActionName("v")]
        public virtual async Task<ActionResult> Details(string slug)
        {
            try
            {
                var page = await _pageService.GetPublicBySlugAsync(slug);

                if (page != null)
                {
                    var type = page.Type == (int)PageTypeEnum.Sections ? PageTypeEnum.Sections : PageTypeEnum.Html;
                    if (type == PageTypeEnum.Html)
                    {
                        return View($"Preview_{type.ToString()}", page);
                    }
                    else
                    {
                        return View($"Preview_{type.ToString()}", page);
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
                return View("Preview_Sections", page);
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
                return View("Preview_HtmlPage", page);
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
