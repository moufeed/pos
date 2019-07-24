using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.SDK.Services.POSs.Directory;
using TamTech.Monshaat.POS.Web.SDK.Services.POSs.Directory.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace TamTechSDK.Web.Controllers.Portal
{
    public class DirectoryController : PublicBaseController
    {
        #region prop
        private readonly IPOSSectorServices _sectorService;
        private readonly IDirectoryServices _directoryServices;
        private readonly IPOSAttributeService _attributeService;
        private readonly IPosTypeService _posTypeService;   
        #endregion

        #region Ctors
        public DirectoryController(
                                            ITelemetryService telemetryClientService,
                                            IPOSSectorServices sectorService,
                                            IDirectoryServices directoryServices,
                                            IPOSAttributeService attributeService,
                                            IPosTypeService posTypeService,
                                             ILogger<DirectoryController> logger,
                                            IStringLocalizer<BaseController>  localizer
                                        ) : base(telemetryClientService, logger, localizer)
        {
            _sectorService = sectorService;
            _directoryServices = directoryServices;
            _attributeService = attributeService;
            _posTypeService = posTypeService;   
        }
        #endregion

        #region Utilities   
        private async Task InitAction()
        {

            ViewBag.sectors = (await _sectorService.GetPublishedListAsync()).Data;
            ViewBag.attributes = (await _attributeService.GetPublishedListAsync()).Data;
            ViewBag.types =( await _posTypeService.GetPublishedListAsync()).Data;
        }     
       
        private PosFilters MakeFiltersModel(string slug, string searchKeyword, string[] filters, string[] types, PaginationModel pagination)
        {
            Filter model = new Filter();
            model.Search = searchKeyword;
            model.SectorSlug = slug;
            model.valIds = string.Join(',', filters);
            model.TypeIds = string.Join(',', types);
            SortingModel sorting = CreateSortingModel(model.SortBy);
            return new PosFilters
            {
                Lang = _lang,
                PageSize = pagination.PageSize,
                PageNumber = int.Parse(pagination.PageNumber),
                SortBy = sorting.SortBy,
                Descending = sorting.Descending,
                Search = GenrateSearchParams(model)
            };
        }

        #endregion

        #region Actions   
        public virtual async Task<IActionResult> Index(string slug, string search, string[] f, string[] t, PaginationModel pagination, IFormCollection collection)
        {
            ViewBag.filters = f;
            ViewBag.types = t;

            await InitAction();
            try
            {
                ViewBag.ActiveSector = slug;
                PosFilters filters = MakeFiltersModel(slug, search, f, t, pagination);
                var request = await _directoryServices.FindAsync(filters);
                if (VerifySucceed(request))
                {
                    TrackException(new Exception("Exception Index by a.aktaa"), slug, search, f, t, new PaginationModel
                    {
                        PageNumber = "ahmad altaa ahmad ",
                        PageSize = 50
                    }
                    );
                    return View(request.Data);
                }
                

            }
            catch (Exception ex)
            {
                TrackException(ex, slug,  search,  f,  t, pagination);
            }
            return View();
        }


        public virtual async Task<IActionResult> Pos(string slug)
        {
            try
            {
                var result = await _directoryServices.GetPublishedBySlugAsync(slug);
                if (VerifySucceed(result))
                {
                    return View(result.Data);
                }

            }
            catch (Exception ex)
            {
                TrackException(ex, slug);
            }
            return View();
        }

        public virtual async Task<PartialViewResult> Search(string slug, string search, string[] f, string[] t, PaginationModel pagination, IFormCollection collection)
        {
            ViewBag.filters = f;
            ViewBag.types = t;
            try
            {
                ViewBag.ReoladScripts = true;
                PosFilters filters = MakeFiltersModel(slug, search, f, t, pagination);
                var request = await _directoryServices.FindAsync(filters);
                if (VerifySucceed(request))
                {
                    return PartialView("~/Areas/Portal/Views/Directory/partials/_results.cshtml", request.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, slug, search, f, t, pagination);
            }
            return PartialView("~/Areas/Portal/Views/Directory/partials/_messages.cshtml");
        }
        #endregion
    }
}
