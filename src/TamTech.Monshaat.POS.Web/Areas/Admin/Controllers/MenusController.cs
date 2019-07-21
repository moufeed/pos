using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Settings.Utilities;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus.Enums;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.Menus.Models;
using TamTech.Monshaat.POS.Web.SDK.Core.Constants;
using TamTech.Monshaat.POS.Web.SDK.Core.Mappers;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Admin.Menus;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using TamTech.Monshaat.POS.Web.SDK.Services.ContentService.ContentCommonUtilities;
using TamTech.Monshaat.POS.SDK.Models.VMs.Admin.Menus;

namespace TamTechSDK.Web.Controllers.Admin
{
  //  [Authorize(Policy = ContentSDKPoliciesConstants.MenusContentAdmin)]
    public class MenusController : AdminBaseController
    {

        #region Props 
        public readonly IMenusServices _MenusServices;
        public readonly ICCUServices _cCUServices;
        private readonly SettingsHelpers _settingsHelpers;
        private readonly IStringLocalizer<BaseController> _localizer;
        private int _MenuMaxLevels { get; set; } = 0;
        #endregion


        #region Ctors
        public MenusController(ITelemetryService telemetryClientService, IMenusServices MenusServices,
           ICCUServices  cCUServices, IStringLocalizer<BaseController> localizer, SettingsHelpers settingsHelpers)
            : base(telemetryClientService, localizer)
        {
            _MenusServices = MenusServices;
            _localizer = localizer;
            _settingsHelpers = settingsHelpers;
            _cCUServices = cCUServices;
        }
        #endregion


        #region Utilities

        public TResult DeserializeFromObject<TResult>(dynamic inputObject)
        {
            string serialized = JsonConvert.SerializeObject(inputObject);
            TResult handledResult = JsonConvert.DeserializeObject<TResult>(serialized);
            return handledResult;
        }

        private async Task GetMenuItemsTypesListsAsync(string lang)
        {
            List<string> types = await _settingsHelpers.GetMenuItemsTypesAsync();
            var menuItemsTypesList = (await _cCUServices.GetListsModulesForMenuItemsTypesAsync(types, lang));

            if (menuItemsTypesList != null)
            {
                foreach (var typeList in menuItemsTypesList.Data)
                {
                    if (typeList.Key.Equals(MenuItemTypeEnum.page.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        ViewBag.PagesSelectList = new SelectList(typeList.Value, "Key", "Value");
                        continue;
                    }
                     
                    
                    

                     
  
                }
            }

            var menu = await _settingsHelpers.GetStaticPagesAsync();
            if (menu != null)
            {
                ViewBag.StaticPagesSelectList = new SelectList(menu, "Url", (lang == "ar") ? "Title_ar" : "Title_en");
            }
        }



        public void PrepareCreating()
        {
            ViewBag.isUpdate = false;
            //GetLanguages();
            ViewBag.index = 0;
        }

        #endregion


        #region Actions

        #region {Menu}  Create / Edit / Delete

        [HttpGet("{Culture}/[Area]/[Controller]/")]
        public virtual async Task<ActionResult> Index()
        {
            //GetLanguages();
            try
            {
                var result = await _MenusServices.GetAllAsync(GetCurrentDataLang());

                if (result.Success)
                {
                    return View(result.Data);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View(new List<MenuLiteDto>());
        }

        [HttpGet("{Culture}/[Area]/[Controller]/Create")]
        public  ActionResult Create(string Culture)
        {
            PrepareCreating();
            return View("CreateForm", new MenuLiteDto());
        }


        [HttpPost("{Culture}/[Area]/[Controller]/Create")]
        public virtual async Task<ActionResult> Create(CreateMenuDto model, IFormCollection collection)
        {
            try
            {
                bool continueEditing = collection.ContainsKey("save-continue");
                TryValidateModel(model);
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var result = await _MenusServices.CreateAsync(model);
                    HandelPostingResult(result, _localizer["menu_creation_successfully"]);
                    if (result.Success)
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
                TrackException(ex);
            }


            PrepareCreating();
            return View("CreateForm", model.MapLiteDtoToCreateDto());
        }


      
        [HttpGet("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public  async Task<ActionResult> Edit(Guid id)
        {
            //GetLanguages();

            await GetMenuItemsTypesListsAsync(GetCurrentDataLang());
            ViewBag.index = 0;
            ViewBag.MenuMaxLevels = _MenuMaxLevels;
            ViewBag.isUpdate = true;



            try
            {
                var result = await _MenusServices.GetByIdAsync(id, GetCurrentDataLang());
                if (result.Success)
                {
                    return View("EditForm", result.Data.MapDtoToEditVM());
                }
                else
                {
                    return RedirectToAction("Create");
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            return View("EditForm", new EditMenuVM());
        }

        [HttpPost("{Culture}/[Area]/[Controller]/Edit/{id}")]
        public  async Task<ActionResult> Edit(EditMenuVM model, IFormCollection collection)
        {
            try
            {
                bool continueEditing = collection.ContainsKey("save-continue");

                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var result = await _MenusServices.EditAsync(model.MapEditVMToDto());
                    HandelPostingResult(result, _localizer["menu_updating_successfully"]);
                    if (result.Success)
                    {
                        if (continueEditing)
                        {
                            return RedirectToAction("Edit", new { id = model.Id });
                        }
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }

            //GetLanguages();
            return View("EditForm", model);
        }


        [HttpGet("{Culture}/[Area]/[Controller]/Delete/{id}")]
        public async virtual Task<IActionResult> Delete(Guid id)
        {

            try
            {
                var result = await _MenusServices.DeleteByIdAsync(id);
                return ReturnJsonResult(result, id);
            }
            catch (Exception ex)
            {
                TrackException(ex);
                return ReturnJsonErrorResult(ex.Message, id);
            }

        }
        #endregion


        #region {Menu Items}  Create / Edit / Delete / Publish 


       
        //Action Return : json
        [HttpPost("{Culture}/[Area]/[Controller]/Items/Create")]
        public  async Task<ActionResult> CreateMenuItemAsync(MenuItemVm  model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    CreateMenuItemDto _model = new CreateMenuItemDto
                    {
                        DisplayOrder = model.DisplayOrder,
                        UrlTarget = model.UrlTarget,
                        Url = model.Url,
                        Title = model.Title,
                        ItemType = model.ItemType,
                        Lang = model.Lang,
                        MenuId = model.MenuId,
                        ParentKey = model.ParentKey
                    };
                     
                    var result = await _MenusServices.CreateMenuItemAsync(_model);
                    
                    //HandelResult(result);
                }
                 
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return RedirectToAction("Edit", new { id = model.MenuId });
        }

         
        [HttpPost("{Culture}/[Area]/[Controller]/Items/Edit")]
        public  async Task<ActionResult> EditMenuItemAsync(MenuItemVm  model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    UpdateMenuItemDto _model = new UpdateMenuItemDto
                    {
                        DisplayOrder = model.DisplayOrder,
                        UrlTarget = model.UrlTarget,
                        Url = model.Url,
                        Title = model.Title,
                        ItemType = model.ItemType,
                        Lang = model.Lang,
                        Key = model.Key,
                        RootMenuId = model.MenuId
                    };
                    var result = await _MenusServices.EditMenuItemAsync(_model);
                      
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return RedirectToAction("Edit", new { id = model.MenuId });
        }




        [HttpGet("{Culture}/[Area]/[controller]/Items/Publish/")]
        public virtual async Task<JsonResult> PublishMenuItemAsync(MenuItemKeysDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Lang = GetCurrentDataLang();
                    var result = await _MenusServices.PublishMenuItemAsync(model);
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
                return ReturnJsonErrorResult(ex.Message, model);
            }
        }


        [HttpGet("{Culture}/[Area]/[controller]/Items/Delete")]
        public virtual async Task<ActionResult> DeleteAsync(MenuItemKeysDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _MenusServices.DeleteMenuItemAsync(model);
                    return ReturnJsonResult(result, model);
                }
                else
                {
                    return ReturnJsonErrorResult(ModelState, model);
                }
            }
            catch (Exception ex)
            {
                TrackException(ex);
                return ReturnJsonErrorResult(ex.Message, model);
            }
        }

        #endregion


        #endregion 
    }


    public class SelectListModel
    {
        public string ItemValue { get; set; }
        public string ItemText { get; set; }

    }

}


