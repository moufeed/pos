using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTechSDK.Common.Models.ContentItem;
using TamTechSDK.Common.Models.Filter;
using TamTechSDK.Common.Models.Sort;
using TamTechSDK.Common.Services.TypesService;
using TamTechSDK.Common.Services.TypesService.Models;
using TamTechSDK.Web.Controllers.Admin;
using TamTechSDK.Web.Extensions.AutoMapper.Types;
using TamTechSDK.Web.Models.Admin.Types;
using TamTechSDK.Web.Models.Shared.Filters;
using TamTechSDK.Web.Services.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    public abstract class BaseTypesController : AdminBaseController
    {
        public readonly ITypeService _typeService;
        private readonly IStringLocalizer<AdminBaseController> _localizer;


        public BaseTypesController(ITelemetryService telemetryClientService,
            IStringLocalizer<AdminBaseController> localizer,
             ITypeService typeService)
            : base(telemetryClientService, localizer)
        {

            _typeService = typeService;
            _localizer = localizer;
        }



        public TypeVM NewTypeVm()
        {
            return new TypeVM()
            {
                Options = new Dictionary<string, bool>
                {
                    { "Attachments" , false },
                    { "CompanyName" , false },
                    { "RegionId" , false }
                }
            };
        }
        #region index
        [HttpGet("{Culture}/[Area]/[controller]")]
        public virtual async Task<IActionResult> Index(Filter model)
        {
            ViewBag.showReset = new Filter().Equals(model);

            ViewBag.FilterModel = model;

            GetDefaultFiltersList(model, "name");

            SortingModel sorting = CreateSortingModel(model.SortBy);

            DTFilter filters = new DTFilter
            {
                Lang = GetCurrentDataLang(),
                PageSize = model.PageSize,
                PageNumber = model.PageNumber,
                SortBy = sorting.SortBy,
                Descending = sorting.Descending,
                Search = GenrateSearchParams(model)
            };

            try
            {
                var types = await _typeService.GetExceptSoftDeletedAsync(filters);

                return View(types);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            return View(new List<TypeDto>());
        }
        #endregion

        #region CREATE
        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<ActionResult> Create()
        {
            TypeVM model = NewTypeVm();
            ViewBag.IsEditMode = false;

            return View("Form", model);
        }


        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<IActionResult> Create(TypeVM model, IFormCollection collection)
        {
            bool continueEditing = collection.ContainsKey("save-continue");

            try
            {
                ModelState.Clear();
                if (TryValidateModel(model))
                {
                    var result = await _typeService.CreateAsync(model.MapToCreateTypeModel());

                    HandelPostingResult(result, _localizer["sector_creation_successfully"]);
                    if (result.Success)
                    {
                        if (continueEditing)
                        {
                            ViewBag.IsEditMode = true;
                            return RedirectToAction("Edit", new { id = result.Data });
                        }

                        return RedirectToAction("Index");
                    }

                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            ViewBag.IsEditMode = false;
            return View("Form", model);
        }
        #endregion

        [HttpGet("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<ActionResult> Edit(int id)
        {
            ViewBag.IsEditMode = true;

            TypeVM model = NewTypeVm();

            try
            {
                var result = await _typeService.GetByIdExceptSoftDeletedAsync(id, GetCurrentDataLang());

                if (result != null)
                    return View("Form", result.MapToTypeVM());

                ViewBag.EmptyResponse = true;

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View("Form", model);
        }



        [HttpPost("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<IActionResult> Edit(TypeVM model, IFormCollection collection, string lang)
        {
            bool continueEditing = collection.ContainsKey("save-continue");

            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();


                    var result = await _typeService.EditAsync(model.MapToUpdateTypeModel());

                    HandelPostingResult(result, _localizer["sector_creation_successfully"]);

                    if (result.Data)
                    {
                        if (continueEditing)
                        {
                            ViewBag.IsEditMode = true;
                            return View("Form", model);
                        }

                        return RedirectToAction("Index");
                    }

                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }


            ViewBag.IsEditMode = true;
            return View("Form", model);
        }



        [HttpGet("{Culture}/[Area]/[Controller]/Publish/{id}")]
        public virtual async Task<JsonResult> PublishAsync(int id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    PublishDTO data = new PublishDTO
                    {
                        IntId = id,
                        Lang = GetCurrentDataLang()

                    };

                    var result = await _typeService.PublishAsync(data);
                    return ReturnJson(result, id);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, id);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(ex.Message, id);
            }
        }


        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _typeService.SoftDeleteAsync(id);
                    return ReturnJson(result, id);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, id);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex);
                return ReturnJsonErrorResult(ex.Message, id);
            }
        }


    }
}
