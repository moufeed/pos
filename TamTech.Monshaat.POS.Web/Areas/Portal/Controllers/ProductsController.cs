using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Pagination;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Products;
using TamTechSDK.Common.Services.ContentService.Products.Models;
using TamTechSDK.Web.Extensions.AutoMapper;
using TamTechSDK.Web.Models.Shared.Products;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Portal
{
    public class ProductsController : PublicBaseController
    {

        private IProductsService _productsService;


        public ProductsController(
            ITelemetryClientService telemetryClientService,
            IProductsService productsService)
            : base(telemetryClientService)
        {
            this._productsService = productsService;
        }

        // [HttpGet("[Area]/[controller]")]
        [HttpGet]
        public virtual async Task<IActionResult> Index([FromQuery] PublicProductFiltrationModel model)
        {
            ViewBag.FilterModel = model;

            var result = await _productsService.GetPublicDynamicListByFiltrationAsync(model);
            if (result.Success)
            {


                var paging = (PaginationMetadataModel)result.Header;
                ViewBag.pagination = paging;

                var data = result.Data.Select(p => p.MapToListViewModel());
                return View(data.ToList());

            }
            return NotFound();

        }
        [HttpGet]
        [ActionName("v")]
        public virtual async Task<IActionResult> Details(Guid id)
        {
            ViewBag.url = GetAbsoluteUri();
            try
            {
                var result = await _productsService.GetPublicDynamicByIdAsync(id);

                if (result != null && result.Success && result.Data != null)
                {
                    return View(result.Data);
                }
                return RedirectToNotFound(id);

            }
            catch (Exception ex)
            {
                TrackException(ex);
                return RedirectToException(ex.Message);
            }


        }
    }
}
