using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.MCI.EFile2.Filters;
using TamTech.Monshaat.POS.Web.SDK.Core.Settings.Utilities;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Attributes.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Types.Models;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Vendors;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Vendors.Models;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;
using TamTech.Monshaat.POS.Web.SDK.Core.Mappers.Vendor;
using TamTech.Monshaat.POS.Web.SDK.Core.Filters;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Portal.Pos;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Portal.vendor;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Sectors.Models;
using TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister;
using TamTech.Monshaat.POS.SDK.Core.Authorizations;
using TamTech.Monshaat.POS.Web.SDK.Core.Enums;
using Microsoft.Extensions.Logging;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;

namespace TamTechSDK.Web.Controllers.Portal
{
    [ServiceFilter(typeof(ActiveVendor))]
    [ServiceFilter(typeof(UserContextUpdated))]
    [ServiceFilter(typeof(AuthorizeEFile))]
    [Authorize(Policy = PolicyConstants.Vendor)]
    //[PermissionAuthorize("User,Vendor")]
    public class VendorController : PublicBaseController
    {
        #region properties
        private readonly IPosTypeService _posTypeService;
        private readonly IPOSSectorServices _sectorService;
        private readonly IPOSAttributeService _attributeService;

        private readonly IUploadManagerService _uploadManager;
        private IStringLocalizer<BaseController> _localizer;
        private readonly IVendorService _vendorServis;
        private readonly SettingsHelpers _settingsHelpers;
        private readonly ICRService _cRService;
        #endregion

        #region constructor
        public VendorController(
            ITelemetryService telemetryClientService,
            IPosTypeService posTypeService,
            IPOSSectorServices sectorService,
            IPOSAttributeService attributeService,
            IUploadManagerService uploadManager,
            IVendorService vendorServis,
            ICRService cRService,
             SettingsHelpers settingsHelpers,
             ILogger<VendorController> logger,
            IStringLocalizer<BaseController> localizer) : base(telemetryClientService, logger, localizer)
        {
            _posTypeService = posTypeService;
            _sectorService = sectorService;
            _attributeService = attributeService;
            _uploadManager = uploadManager;
            _localizer = localizer;
            _vendorServis = vendorServis;
            _settingsHelpers = settingsHelpers;
            _cRService = cRService;

        }
        #endregion

        #region utilities

        private readonly static Dictionary<string, string> _VIEWS = new Dictionary<string, string> {
            {"VendorForm","~/Areas/Portal/Views/Vendor/VendorForm.cshtml" },
            {"VendorInfo","~/Areas/Portal/Views/Vendor/VendorInfo.cshtml" },
        };

        private List<SelectListItem> CreateTypeSelect(List<TypeDto> types, int TypeId = 0)
        {
            List<SelectListItem> _Types = new List<SelectListItem>();

            foreach (TypeDto item in types)
            {
                _Types.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Selected = item.Id == TypeId,
                });
            }
            return _Types;
        }

        private List<AttributeDto> CreateAttributes(PosFormVm model, List<AttributeDto> attributes, bool isUpdate = false)
        {

            if (isUpdate && model.SpecificationsB.Count > 0)
            {

                foreach (var item in model.SpecificationsB)
                {
                    foreach (var val in item.Values)
                    {
                        var valueDto = attributes.Where(att => att.Id == item.Id).SelectMany(att => att.Values).FirstOrDefault(v => v.Id == val.Id);
                        if (valueDto != null)
                            valueDto.Checked = true;
                    }

                }
            }
            attributes.ForEach(s =>
            {
                s.Values = s.Values.OrderBy(v => v.Id).ToList();
            });
            return attributes;

        }
        private async Task InitAction(PosFormVm model, bool isUpdate = false)
        {
            var types = await _posTypeService.GetPublishedListAsync();


            ViewBag.TypsSelect = VerifySucceed(types) ? CreateTypeSelect(types.Data, model.TypeId) : CreateTypeSelect(new List<TypeDto>(), model.TypeId);

            var _sectors = await _sectorService.GetPublishedListAsync(); ;
            ViewBag.sectors = VerifySucceed(_sectors) ? _sectors.Data : new List<SectorDto>();
            var attributes = await _attributeService.GetPublishedListAsync();
            ViewBag.attributes = VerifySucceed(attributes) ? CreateAttributes(model, attributes.Data, isUpdate) : CreateAttributes(model, new List<AttributeDto>(), isUpdate);

        }
        #endregion

        #region index
  
        public virtual async Task<IActionResult> Index() => RedirectToAction("index", "pos");

        #endregion



        #region Vendors



        #region CREATE VENDOR
        [NonAction]
        public async Task<VendorFormVm> GetPersonAsync()
        {
            var result = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
            if (VerifySucceed(result))
            {
                return result.Data.MapToVendorFormVm();
            }

            return null;
        }

     
        public virtual async Task<IActionResult> Register()
        {
            try
            {
                string userPermission = HttpContext.User.Identity.GetPermission();
                if (User.Identity.IsAuthenticated)
                {
                    if (userPermission == PermissionTypeEnum.Vendor.ToString())
                    {
                        return RedirectToAction("edit");
                    }
                    else
                    {
                        bool registeredVendor = (await _vendorServis.CheckTheCurrentUserIsRegisteredAsVendorAsync()).Data;
                        if (registeredVendor)
                        {
                            return RedirectToAction("Info");
                        }

                        return View(_VIEWS["VendorForm"]);
                    }
                }
                else
                {
                    return View(_VIEWS["VendorForm"]);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(_VIEWS["VendorForm"]);
        }


        [HttpPost]     
        public virtual async Task<IActionResult> Register(VendorFormVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CreatePersonModel _CreateModel = model.MapVendorFormVmToCreatePersonModelWithoutAttachments();
                    var result = await _vendorServis.CreateAsync(_CreateModel);
                    if (result.Success)
                    {
                        TempData["RegisterSuccess"] = model.CompanyName;
                        ModelState.Clear();
                        var _model = new VendorFormVm();
                        return View(_VIEWS["VendorForm"], _model);
                    }
                    else if (result.Messages.Count > 0)
                    {
                        AddModelStateError(result.Messages);
                    }
                }

            }
            catch (Exception ex)
            {
                TrackException(ex, model);
            }
            //  await InitAction(model);
            return View(_VIEWS["VendorForm"], model);
        }
        #endregion

        #region EDIT VENDOR
                     
        public virtual async Task<IActionResult> Edit()
        {
            VendorFormVm person = null;
            try
            {
                string userPermission = HttpContext.User.Identity.GetPermission();
            if (User.Identity.IsAuthenticated)
            {
                  person = await GetPersonAsync();

                if (userPermission == PermissionTypeEnum.Vendor.ToString()
                    || (person != null && person.VendorCanEdit == true))
                {
                    return View(_VIEWS["VendorForm"], person);
                }
                else
                {
                    return RedirectToAction("Info");
                }
            }
            else
            {
                return RedirectToAction("Register");
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, person);
            }
            return View(_VIEWS["VendorForm"]);
        }

        [HttpPost]       
        public virtual async Task<IActionResult> Edit(VendorFormVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _vendorServis.EditAsync(model.MapToUpdatePersonModel());
                    if (result.Success)
                    {
                        TempData["UpdateSuccess"] = true;
                        var Person = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
                        if (VerifySucceed(Person))
                        {
                            return View(_VIEWS["VendorForm"], Person.Data.MapToVendorFormVm());
                        }


                    }
                    else if (result.Messages.Count > 0)
                    {
                        AddModelStateError(result.Messages);
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, model);
            }


            return View(_VIEWS["VendorForm"], model);
        }

        #endregion


        #region VALDATE VENDOR COMMERCIAL NUMBER
        [HttpGet]
        public async virtual Task<JsonResult> ValidateCommercialNoIsExist(string number, Guid id, IFormCollection collection)
        {
            try
            {
                var result = await _vendorServis.VerifyCRUniqueAsync(number, id != Guid.Empty ? id : (Guid?)null);
                if (result.Success)
                {
                    return Json(result.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, number, id);
            }

            return Json(new { success = false });
        }



        [HttpGet]
        public async virtual Task<JsonResult> ValidateVendorBelongsToCR(string crNumber)
        {
            try
            {
                var username = HttpContext.User.Identity.GetUsername();
                var result = await _cRService.CheckNationalIdBelongsToCR(new TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister.Models.CRIncludeNationalIdModel
                {
                    CommercialRegister = crNumber,
                    NationalId = HttpContext.User.Identity.GetUsername()
                });

                return Json(new { success = result.Successed });
            }
            catch (Exception ex)
            {
                TrackException(ex, crNumber);
            }

            return Json(new { success = false });
        }
        #endregion




        #region VALDATE VENDOR NAME
        [HttpGet]
        public async virtual Task<JsonResult> ValidateVendorNameIsExist(string name, Guid id, IFormCollection collection)
        {
            try
            {
                var result = await _vendorServis.VerifyVendorSlugUniqueByNameAsync(name, id != Guid.Empty ? id : (Guid?)null);
                if (result.Success)
                {
                    return Json(result.Data.Unique);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, name, id);
            }

            return Json(new { success = false });
        }


        #endregion
        #endregion

        #region VENDOR INFO
                                                                    
        public virtual async Task<IActionResult> Info()
        {
            IRequestProviderResult<PersonDto> result = null;
            try
            {
                  result = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
                if (VerifySucceed(result))
                {
                    return View(_VIEWS["VendorInfo"], result.Data.MapToVendorFormVm());
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, result);
            }
            return View(_VIEWS["VendorInfo"]);
        }

        #endregion




        // just for development              
        public virtual async Task<IActionResult> Devinfo()
        {
            IRequestProviderResult<PersonDto> result = null;
            try
            {
                  result = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
                if (VerifySucceed(result))
                {
                    return View("Devinfo", result.Data.MapToVendorFormVm());
                }
            }
            catch (Exception ex)
            {
                TrackException(ex, result);
            }
            return View("Devinfo", new VendorFormVm());
        }


    }
}

          