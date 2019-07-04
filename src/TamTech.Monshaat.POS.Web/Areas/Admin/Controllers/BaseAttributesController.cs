using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.Core.Mappers.Attributes;
using TamTech.Monshaat.POS.Web.Models.VMs.Admin.Attributes;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.Core.Telemetry;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes.Models;

namespace TamTechSDK.Web.Controllers.Admin
{
    public abstract class BaseAttributesController : AdminBaseController
    {
        public readonly IAttributeService _attributeService;
        private readonly IStringLocalizer<AdminBaseController> _localizer;


        public BaseAttributesController(ITelemetryService telemetryClientService,
            IStringLocalizer<AdminBaseController> localizer,
             IAttributeService attributeService)
            : base(telemetryClientService, localizer)
        {

            _attributeService = attributeService;
            _localizer = localizer;
        }



        //public AttributeVM NewTypeVm()
        //{
        //    return new AttributeVM()
        //    {
        //        Options = new Dictionary<string, bool>
        //        {
        //            { "Attachments" , false },
        //            { "CompanyName" , false },
        //            { "RegionId" , false }
        //        }
        //    };
        //}

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
                var types = await _attributeService.GetAsync(filters);
                return View(types);
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View(new List<AttributeDto>());
        }



        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<ActionResult> Create()
        {
            // AttributeVM  model =  NewTypeVm();
            AttributeVM model = new AttributeVM();
            ViewBag.IsEditMode = false;

            return View("Form", model);
        }


        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<IActionResult> Create(AttributeVM model, IFormCollection collection)
        {
            bool continueEditing = collection.ContainsKey("save-continue");

            try
            {
                ModelState.Clear();
                if (TryValidateModel(model))
                {
                    var result = await _attributeService.CreateAsync(model.MapToCreateAttributeModel());

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


        [HttpGet("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<ActionResult> Edit(int id)
        {
            ViewBag.IsEditMode = true;

            AttributeVM model = new AttributeVM();

            try
            {
                var result = await _attributeService.GetByIdAsync(id, GetCurrentDataLang());

                if (result != null)
                    return View("Form", result.MapToAttributeVM());

                ViewBag.EmptyResponse = true;

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View("Form", model);
        }



        [HttpPost("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public virtual async Task<IActionResult> Edit(AttributeVM model, IFormCollection collection, string lang)
        {
            bool continueEditing = collection.ContainsKey("save-continue");

            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();


                    var result = await _attributeService.EditAsync(model.MapToUpdateAttributeModel());

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

                    var result = await _attributeService.PublishAsync(data);
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
                    var result = await _attributeService.SoftDeleteAsync(id);
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
