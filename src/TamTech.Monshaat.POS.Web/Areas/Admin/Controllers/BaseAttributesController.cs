using System;    
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Common;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Filter;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.SDK.Core.Mappers.Attributes;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Attributes;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using Microsoft.Extensions.Logging;        

namespace TamTechSDK.Web.Controllers.Admin
{   
    public abstract class BaseAttributesController : AdminBaseController
    {
        public readonly IAttributeService _attributeService;
        private readonly IStringLocalizer<BaseController> _localizer;


        public BaseAttributesController(ITelemetryService telemetryClientService,
              ILogger<BaseAttributesController> logger,
            IStringLocalizer<BaseController> localizer,
             IAttributeService attributeService)
            : base(telemetryClientService, logger, localizer)
        {

            _attributeService = attributeService;
            _localizer = localizer;
        }


 

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
                TrackException(ex, model);
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

                if (VerifySucceed(result))
                {
                    return View("Form", result.Data.MapToAttributeVM());
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, id);
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
                TrackException(ex, model);
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
                    PublishLookupModel data = new PublishLookupModel
                    {
                        Id = id,
                        Lang = GetCurrentDataLang()

                    };

                    var result = await _attributeService.PublishAsync(data);
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
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _attributeService.SoftDeleteAsync(id);
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
