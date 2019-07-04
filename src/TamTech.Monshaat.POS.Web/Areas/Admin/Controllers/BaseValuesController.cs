using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.Services.ValuesServices;
using TamTech.Monshaat.POS.Web.Core.Mappers.Values;
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.Values;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.Core.Telemetry;

namespace TamTechSDK.Web.Controllers.Admin
{
    public abstract class BaseValuesController : AdminBaseController
    {

        public readonly IValueService _valuesServices;
        public readonly IAttributeService _attributesServices;
        private readonly IStringLocalizer<AdminBaseController> _localizer;

        public BaseValuesController(ITelemetryService telemetryClientService, IStringLocalizer<AdminBaseController> localizer,
            IValueService valuesServices, IAttributeService attributesServices) : base(telemetryClientService, localizer)
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
                if (_attributes != null && _attributes.Count > 0)
                {
                    ViewBag.attributes = new SelectList(_attributes, "Value", "Text", id != 0 ? id : (int?)null);
                }
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
                return View(types);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View(new List<ValueVM>());
        }



        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<ActionResult> Create()
        {

            await _GetAttributesList();



            ValueVM model = new ValueVM();
            ViewBag.IsEditMode = false;

            return View("Form", model);
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

                if (result != null)
                {
                    await _GetAttributesList(result.AttId);
                    return View("Form", result.MapToValueVM());
                }

                ViewBag.EmptyResponse = true;

            }
            catch (Exception ex)
            {
                TrackException(ex);
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



                    if (result.Data)
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
                TrackException(ex);
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
                    PublishDTO data = new PublishDTO
                    {
                        IntId = id,
                        Lang = GetCurrentDataLang()

                    };

                    var result = await _valuesServices.PublishAsync(data);
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
        public virtual async Task<JsonResult> DeleteAsync(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _valuesServices.SoftDeleteAsync(id);
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
