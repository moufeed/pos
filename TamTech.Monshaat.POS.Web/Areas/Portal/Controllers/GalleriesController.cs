using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Galleries;
using TamTechSDK.Web.Services.Telemetry;
using TamTechSDK.Common.Services.ContentService.Galleries.Models;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;

namespace TamTechSDK.Web.Controllers.Portal
{
    public class GalleriesController : PublicBaseController
    {
        IGalleriesService _galleriesService;
        public GalleriesController(ITelemetryClientService telemetryClientService,
            IGalleriesService galleriesService) : base(telemetryClientService)
        {
            _galleriesService = galleriesService;
        }


        public virtual async Task<IActionResult> Index(PaginationModel Pagination)
        {


            GalleryList galleries = new GalleryList();

            try
            {

                var result = await _galleriesService.GetPublicListAsync(Pagination);
                galleries.Data = result.Data;
                galleries.Pagination = result.Pagination;

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(galleries);
        }

        [ActionName("s")]
        public virtual async Task<IActionResult> Section(PaginationModel Pagination, string slug)
        {


            GalleryList galleries = new GalleryList();

            try
            {

                var result = await _galleriesService.GetPublicListAsync(Pagination, slug);
                galleries.Data = result.Data;
                galleries.Pagination = result.Pagination;
                galleries.SectionsSlugs = result.SectionsSlugs;
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("index", galleries);

        }

        [ActionName("v")]
        public virtual async Task<IActionResult> Details(string slug)
        {
            var lang = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            GalleryDto gallery = new GalleryDto();
            try
            {
                var result = await _galleriesService.GetPublicBySlugAsync(slug, lang);
                if (result.Success)
                {
                    return View("gallery", result.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return NotFound();
        }
    }
}
