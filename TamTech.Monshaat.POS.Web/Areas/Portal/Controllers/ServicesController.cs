
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Services;
using TamTechSDK.Common.Services.ContentService.Services.Models;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Portal
{
    public class ServicesController : PublicBaseController
    {
        public static SortingModel SortByOrder = new SortingModel()
        {

            SortBy = "DisplayOrder"
        };

        //public SortingModel SortByOrder { get; set; }
        private readonly IServicesService _ServicesService;
        public ServicesController(ITelemetryClientService telemetryClientService,
             IServicesService ServicesService)
            : base(telemetryClientService)
        {
            _ServicesService = ServicesService;
            //   SortByOrder = _SortByOrder;
        }

        #region Actions
        // [HttpGet("[Area]/{lang}/[Controller]/")]
        public virtual async Task<IActionResult> Index(PaginationModel Pagination)
        {
            ServiceList ServicesList = new ServiceList();


            try
            {

                var result = await _ServicesService.GetPublicListAsync(Pagination);
                ServicesList.Data = result.Data;
                ServicesList.Pagination = result.Pagination;
                ServicesList.SectionsSlugs = result.SectionsSlugs;
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(ServicesList);

        }

        //     [HttpGet("[Area]/{lang}/[Controller]/{slug}")]

        [ActionName("s")]
        public virtual async Task<IActionResult> ServicesBySection(PaginationModel Pagination, string slug)
        {


            ServiceList ServicesList = new ServiceList();

            try
            {

                var result = await _ServicesService.GetPublicListAsync(Pagination, slug, SortByOrder);
                ServicesList.Data = result.Data;
                ServicesList.Pagination = result.Pagination;
                ServicesList.SectionsSlugs = result.SectionsSlugs;
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("index", ServicesList);

        }

        [ActionName("v")]
        public virtual async Task<IActionResult> Details(string slug)
        {
            ServiceDto Service = new ServiceDto();
            try
            {
                var result = await _ServicesService.GetPublicBySlugAsync(slug);
                if (result.Success)
                {
                    return View("ServiceDetail", result.Data);
                }

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return RedirectToNotFound(slug);
        }
        #endregion
    }
}

