using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Values;
using TamTech.Monshaat.POS.Web.SDK.Core.Mappers.Values;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Values;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.SelectList;
using Microsoft.Extensions.Logging;

namespace TamTechSDK.Web.Controllers.Admin
{
    
    public abstract class BaseValuesController : AdminBaseController
    {

        public readonly IValueService _valuesServices;
        public readonly IAttributeService _attributesServices;
        private readonly IStringLocalizer<BaseController> _localizer;

        public BaseValuesController(ITelemetryService telemetryClientService,
              ILogger<BaseValuesController> logger,
            IStringLocalizer<BaseController> localizer,
            IValueService valuesServices, IAttributeService attributesServices) 
            : base(telemetryClientService, logger, localizer)
        {
            _valuesServices = valuesServices;
            _attributesServices = attributesServices;
        }
         
        #region utilities
        private async Task _GetAttributesList(int id = 0)
        {
            try
            {
                var _attributes = await _attributesServices.GetAllSelectListAsync(GetCurrentDataLang());
                var _attrs = VerifySucceed(_attributes) ? _attributes.Data : new List<SelectListItemModel>();
                ViewBag.attributes = new SelectList(_attrs, "Value", "Text", id != 0 ? id : (int?)null);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
        }
        #endregion

        [HttpGet("{Culture}/[Area]/[controller]")]
        public virtual async Task<IActionResult> Index(Filter model)
        {

            ViewBag.showReset = new Filter().Equals(model);
            ViewBag.FilterModel = model;
            GetDefaultFiltersList(model, "name");
            await _GetAttributesList(model.AttId);
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
                var types = await _valuesServices.GetExceptSoftDeletedAsync(filters);
                return View(VerifySucceed(types) ? types.Data : null);
            }
            catch (Exception ex)
            {
                TrackException(ex, model);
            }

            return View();
        }
         
        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<ActionResult> Create()
        {

            await _GetAttributesList();
            ViewBag.IsEditMode = false;
            return View("Form", new ValueVM());
        }
          
        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<IActionResult> Create(ValueVM model, IFormCollection collection)
        {
            bool continueEditing = collection.ContainsKey("save-continue");

            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _valuesServices.CreateAsync(model.MapToCreateValueModel());

                    if (VerifySucceed(result))
                    {
                        if (continueEditing)
                        {
                            return RedirectToAction("Edit", new { id = result.Data });
                        }

                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, model);
            }
            ViewBag.IsEditMode = false;
            await _GetAttributesList();
            return View("Form", model);
        }
         
        [HttpGet("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<ActionResult> Edit(int id)
        {
            ViewBag.IsEditMode = true;
            ValueVM model = new ValueVM();
            try
            {
                var result = await _valuesServices.GetByIdExceptSoftDeletedAsync(id, GetCurrentDataLang());
                if (VerifySucceed(result))
                {
                    await _GetAttributesList(result.Data.AttId);
                    return View("Form", result.Data.MapToValueVM());
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, id);
            }
            await _GetAttributesList();
            return View("Form", model);
        }
         
        [HttpPost("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<IActionResult> Edit(ValueVM model, IFormCollection collection, string lang)
        {
            bool continueEditing = collection.ContainsKey("save-continue");
            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var result = await _valuesServices.EditAsync(model.MapToUpdateAttributeModel());
                    if (VerifySucceed(result))
                    {
                        if (continueEditing)
                        {
                            ViewBag.IsEditMode = true;
                            await _GetAttributesList(model.AttId);
                            return View("Form", model);
                        }
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, model);
            }
            await _GetAttributesList(model.AttId);
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
                    PublishLookupModel data = new PublishLookupModel
                    {
                        Id = id,
                        Lang = GetCurrentDataLang()

                    };

                    var result = await _valuesServices.PublishAsync(data);
                    return ReturnJsonResult(result, id);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, id);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex, id);
                return ReturnJsonErrorResult(ex.Message, id);
            }
        }
         
        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{id}")]
        public virtual async Task<JsonResult> DeleteAsync(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _valuesServices.SoftDeleteAsync(id);
                    return ReturnJsonResult(result, id);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, id);
                }
            }
            catch (Exception ex)
            {
                TrackExceptionOnly(ex, id);
                return ReturnJsonErrorResult(ex.Message, id);
            }
        }
         
    }
}
