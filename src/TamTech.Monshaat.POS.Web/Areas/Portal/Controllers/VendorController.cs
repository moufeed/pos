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
using TamTech.Monshaat.POS.Web.Models.Dtos.Attachments;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes;
using TamTech.Monshaat.POS.Web.Services.ContentService.Attributes.Models;
using TamTech.Monshaat.POS.Web.Services.POSs.Directory.Models;
using TamTech.Monshaat.POS.Web.Services.POSs;
using TamTech.Monshaat.POS.Web.Services.POSs.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types;
using TamTech.Monshaat.POS.Web.Services.ContentService.Types.Models;
using TamTech.Monshaat.POS.Web.Services.Upload;
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors;
using TamTech.Monshaat.POS.Web.Services.ContentService.Vendors.Models;
using TamTech.Monshaat.POS.Web.Core.Constants;
using TamTech.Monshaat.POS.Web.Core.Extensions;
using TamTech.Monshaat.POS.Web.Core.Mappers.Pos;
using TamTech.Monshaat.POS.Web.Core.Mappers.Vendor;
using TamTech.Monshaat.POS.Web.Core.Filters;
using TamTech.Monshaat.POS.Web.Models.VMs.Portal.Pos;
using TamTech.Monshaat.POS.Web.Models.VMs.Portal.vendor;
using TamTech.Monshaat.POS.Web.Core.Telemetry;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using TamTech.Monshaat.POS.Web.Services.Upload.Models;
using TamTech.Monshaat.POS.Web.Services.ContentService.Sectors.Models;

namespace TamTechSDK.Web.Controllers.Portal
{
    [ServiceFilter(typeof(UserActivityFilter))]
    [ServiceFilter(typeof(UserContextUpdatedFilter))]

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
                                    SettingsHelpers settingsHelpers) : base(telemetryClientService ,localizer)
        {
            _posTypeService = posTypeService;
            _sectorService = sectorService;
            _attributeService = attributeService;
            _uploadManager = uploadManager;
            _localizer = localizer;
            _vendorServis = vendorServis;
            _settingsHelpers = settingsHelpers;
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
        public async Task<IActionResult> PrepareVendorForm(bool editMode)
        {
            VendorFormVm model = null;
            //<<<<< Case 1 :  Not anonymous user >>>>>
            if (User.Identity.IsAuthenticated)
            {
                var roles = HttpContext.User.Identity.GetUserRoles();
                string vendorRole = await _settingsHelpers.GetVendorRoleNameAsync();
                if (roles != null && roles.All(v => v.Equals(vendorRole, StringComparison.InvariantCultureIgnoreCase)))
                {
                    var _isRegistered = await _vendorServis.CheckTheCurrentUserIsRegisteredAsVendorAsync();
                    if (_isRegistered.Data)
                    {
                        //<<<<< Case 1-A1 : vendor info editing mode  >>>>>
                        if (editMode)
                        {
                            try
                            {
                                var result = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
                                if (VerifySucceed(result))
                                {
                                    return View(_VIEWS["VendorForm"], result.Data.MapToVendorFormVm());
                                }
                              
                            }
                            catch (Exception ex)
                            {
                                TrackException(ex);
                            }
                        }
                        var IsVendorRole = User.Identity.GetUserRolesCommaSeparated()?.Equals(TamTech.Monshaat.POS.EFile2.Utilities.Helpers.VendorRole, StringComparison.InvariantCultureIgnoreCase);
                        if (IsVendorRole != null && (bool)IsVendorRole)
                        {
                            return RedirectToAction("edit");
                        }
                        else
                        {
                            var result = await _vendorServis.GetPersonForCurrentUserAsync(_lang);
                            if (VerifySucceed(result))
                            {
                                return View(_VIEWS["VendorForm"], result.Data.MapToVendorFormVm());
                            }
                        }
                        //<<<<< Case 1-A2 : Already is registered as vendor >>>>>
                    }
                    else
                    {
                        //<<<<< Case 1-B1 : vendor info editing mode  >>>>>
                        if (editMode)
                        {
                            return RedirectToAction("register");
                        }
                        //<<<<< Case 1-B2 : Is not registered as a vendor (active Registeration Form)  >>>>>
                        model = new VendorFormVm();
                    }
                }
                else
                {
                    // When AccessDenied is true will the "Access Denied" message be activated
                    ViewBag.ActivateAccessDeniedForAdmins = true;
                }

            }
            //<<<<< Case 2 :  Anonymous user (active view message) >>>>>
            else
            {
                // When AccessDenied is false will the <<<<"please Login/Signup via SSO">>>> message be activated
                ViewBag.ActivateAccessDeniedForAdmins = false;
            }
            return View(_VIEWS["VendorForm"], model);
        }


        public virtual async Task<IActionResult> Register()
        {
            return await PrepareVendorForm(false);
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
            return await PrepareVendorForm(true);
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
            return View(_VIEWS["VendorInfo"], new VendorFormVm());
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
