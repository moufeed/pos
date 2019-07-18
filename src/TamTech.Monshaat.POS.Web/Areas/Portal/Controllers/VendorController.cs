using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.EFile2.Utilities.Filters;
using TamTech.Monshaat.POS.Web.Core.Settings.Utilities;      
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes.Models;   
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types.Models;
using TamTech.Monshaat.POS.Web.Services.Upload;
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Core.Extensions;      
using TamTech.Monshaat.POS.Web.Core.Mappers.Vendor;
using TamTech.Monshaat.POS.Web.Core.Filters;
using TamTech.Monshaat.POS.Web.Models.VMs.Portal.Pos;
using TamTech.Monshaat.POS.Web.Models.VMs.Portal.vendor;
using TamTech.Monshaat.POS.Web.Core.Telemetry;     
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors.Models;
using TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister;
using TamTech.Monshaat.POS.SDK.Core.Authorizations;     
using TamTech.Monshaat.POS.Web.Core.Enums;

namespace TamTechSDK.Web.Controllers.Portal
{
    [ServiceFilter(typeof(ActiveVendor))]
    [ServiceFilter(typeof(UserContextUpdated))]
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
            IStringLocalizer<BaseController> localizer,
            IVendorService vendorServis,
                                    SettingsHelpers settingsHelpers,
                                    ICRService cRService) : base(telemetryClientService ,localizer)
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
            ViewBag.attributes = VerifySucceed(attributes) ?  CreateAttributes(model, attributes.Data, isUpdate) : CreateAttributes(model, new List<AttributeDto>(), isUpdate);

        }
        #endregion

        #region index
        [Authorize(Policy = ContentSDKPoliciesConstants.Vendor)]
        public virtual async Task<IActionResult> Index() => RedirectToAction("index", "pos");

        #endregion



        #region Vendors



        #region CREATE VENDOR
        [NonAction]
        public  async Task<VendorFormVm> GetPersonAsync()
        {
            var result = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
            if (VerifySucceed(result))
            {
                return    result.Data.MapToVendorFormVm() ;
            }

           return null;
        }
        [NonAction]
        public async Task<IActionResult> NewPrepareVendorForm(bool editMode)
        {          
            string userPermission = HttpContext.User.Identity.GetPermission();
            if (User.Identity.IsAuthenticated)
            {
                if (userPermission == PermissionTypeEnum.Vendor.ToString())
                {
                    if (editMode)
                    {   
                        return View(_VIEWS["VendorForm"], await GetPersonAsync());
                    }
                    return RedirectToAction("edit");
                }
                if (userPermission == PermissionTypeEnum.User.ToString() && !editMode)
                {
                    bool registeredVendor = (await _vendorServis.CheckTheCurrentUserIsRegisteredAsVendorAsync()).Data;
                    if (registeredVendor)
                    {
                        return RedirectToAction("Info");
                    }      
                }
                return View(_VIEWS["VendorForm"], new VendorFormVm());
            }

            if (editMode)
            {
                return RedirectToAction("Register");
            }

            return View(_VIEWS["VendorForm"] );

        }        
     public virtual async Task<IActionResult> Login()
        {
            return View();
        }
        [Authorize]
        public virtual async Task<IActionResult> Register()
        {
            return await NewPrepareVendorForm(false);
        }


        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(AuthorizeEFile))]
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
                TrackException(ex);
            }
            //  await InitAction(model);
            return View(_VIEWS["VendorForm"], model);
        }
        #endregion

        #region EDIT VENDOR

        [Authorize]
        public virtual async Task<IActionResult> Edit()
        {    
            return await NewPrepareVendorForm(true);
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(AuthorizeEFile))]
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
                TrackException(ex);
            }


            return View(_VIEWS["VendorForm"], model);
        }

        #endregion


        #region VALDATE VENDOR COMMERCIAL NUMBER
        [HttpPost]
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
                TrackException(ex);
            }

            return Json(new { success = false });
        }



        [HttpPost]
        public async virtual Task<JsonResult> ValidateVendorBelongsToCR(string crNumber )
        {
            try
            {
             var username = HttpContext.User.Identity.GetUsername();     
             var result =  await  _cRService.CheckNationalIdBelongsToCR(new TamTech.Monshaat.POS.Services.ExternalServices.CommercialRegister.Models.CRIncludeNationalIdModel
                {
                    CommercialRegister = crNumber,
                    NationalId = HttpContext.User.Identity.GetUsername()
                });   
                 
                    return Json(new { success = result.Successed });     
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return Json(new { success = false });
        }
        #endregion




        #region VALDATE VENDOR NAME
        [HttpPost]
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
                TrackException(ex);
            }

            return Json(new { success = false });
        }


        #endregion
        #endregion

        #region VENDOR INFO


        [Authorize(Policy = ContentSDKPoliciesConstants.Vendor)]
        public virtual async Task<IActionResult> Info()
        {
            try
            {
                var result = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
                if (VerifySucceed(result))
                {
                    return View(_VIEWS["VendorInfo"], result.Data.MapToVendorFormVm());
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(_VIEWS["VendorInfo"]);
        }

        #endregion

       


        // just for development
        [Authorize(Policy = ContentSDKPoliciesConstants.Vendor)]
        public virtual async Task<IActionResult> Devinfo()
        {
            try
            {
                var result = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
                if (VerifySucceed(result))
                {
                    return View("Devinfo", result.Data.MapToVendorFormVm());
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Devinfo", new VendorFormVm());
        }


    }
}



//public virtual async Task<IActionResult> Register()
//{
//    VendorFormVm model = null;

//    //<<<<< Case 1 :  Not anonymous user >>>>>
//    if (User.Identity.IsAuthenticated)
//    {
//        var roles = HttpContext.User.Identity.GetUserRoles();
//        if (roles != null && roles.All(v => _appSettings.GetVendorRolesName().Contains(v)))
//        {
//            if (await _vendorServis.CheckTheCurrentUserIsRegisteredAsVendorAsync())
//            {
//                //<<<<< Case 1-A : Already is registered as vendor >>>>>
//                return RedirectToAction("edit");
//            }
//            else
//            {
//                //<<<<< Case 1-B : Is not registered as a vendor (active Registeration Form)  >>>>>
//                model = new VendorFormVm();
//            }
//        }
//        else
//        {
//            // When AccessDenied is true will the "Access Denied" message be activated
//            ViewBag.ActivateAccessDeniedForAdmins = true;
//        }

//    }
//    //<<<<< Case 2 :  Anonymous user (active view message) >>>>>
//    else
//    {
//        // When AccessDenied is false will the <<<<"please Login/Signup via SSO">>>> message be activated
//        ViewBag.ActivateAccessDeniedForAdmins = false;
//    }
//    return View(_VIEWS["VendorForm"], model);
//}
