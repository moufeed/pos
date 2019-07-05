using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Models.Dtos.Pagination;
using TamTech.Monshaat.POS.Web.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.Services.POSs.Directory;
using TamTech.Monshaat.POS.Web.Services.POSs.Directory.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.Core.Telemetry;

namespace TamTechSDK.Web.Controllers.Portal
{
    public class DirectoryController : PublicBaseController
    {

        private readonly ISectorServices _sectorService;
        private readonly IDirectoryServices _directoryServices;
        private readonly IPOSAttributeService _attributeService;
        private readonly IPosTypeService _posTypeService;
        public DirectoryController(
                                            ITelemetryService telemetryClientService,
                                            ISectorServices sectorService,
                                            IDirectoryServices directoryServices,
                                            IPOSAttributeService attributeService,
                                            IPosTypeService posTypeService
                                        ) : base(telemetryClientService)
        {
            _sectorService = sectorService;
            _directoryServices = directoryServices;
            _attributeService = attributeService;
            _posTypeService = posTypeService;
        }


        private async Task InitAction()
        {

            ViewBag.sectors = await _sectorService.GetPublishedListAsync();
            ViewBag.attributes = await _attributeService.GetPublishedListAsync();
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
                return View(request);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View();
        }


        public virtual async Task<IActionResult> Pos(string slug)
        {
            try
            {
                var result = await _directoryServices.GetPublishedBySlugAsync(slug);
                return View(result);
            }
            catch (Exception ex)
            {
                TrackException(ex);
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
                return PartialView("~/Areas/Portal/Views/Directory/partials/_results.cshtml", request);
            }
            catch (Exception ex)
            {
                TrackException(ex);
                return PartialView("~/Areas/Portal/Views/Directory/partials/_messages.cshtml");
            }

        }
    }
}
