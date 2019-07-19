using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Telemetry;
using Microsoft.AspNetCore.Authorization;
using TamTech.Monshaat.POS.Web.Services.Upload.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using TamTech.Monshaat.POS.Web.Core.Filters;
using TamTech.Monshaat.POS.Web.Core.Cultures;       
using TamTech.Monshaat.POS.Web.Models.VMs.Shared.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace TamTechSDK.Web.Controllers.Admin
{
    [Area("Admin")]
    [ServiceFilter(typeof(AdminFilter))]
     [Authorize]
    public abstract class AdminBaseController : BaseController
    {


        private readonly IStringLocalizer<BaseController> _localizer;




        public AdminBaseController(ITelemetryService telemetryClientService, IStringLocalizer<BaseController> localizer)
          : base(telemetryClientService, localizer)
        {

            ViewData["Area"] = "Admin";
            _localizer = localizer;
        }




       



      
        public void HandelGetingResult(dynamic result)
        {
            var disableSuccessMode = true;
            HandelResult(result, disableSuccessMode);
        }
        public void HandelPostingResult(dynamic result, string successMsg)
        {
            var disableSuccessMode = false;
            HandelResult(result, disableSuccessMode, successMsg);
        }


       
        public override void TrackException(Exception exc)
        {
            AddErrorModel("Exeption", exc.Message);
            base.TrackException(exc);
        }
        public void TrackExceptionOnly(Exception exc)
        {
            base.TrackException(exc);
        }



        public void TrackIfNotFilesDeleted(bool success,
                                           HttpStatusCode statusCode,
                                            DeleteFilesModelResult resultModel,
                                            dynamic inputModel)
        {
            if (success)
            {
                var errorlist = resultModel.Results.Where(item => item.Result == DeleteResult.NotDeleted);
                if (errorlist != null && errorlist.Count() > 0)
                {
                    TrackEvent("TrackIfNotFilesDeleted_Result", errorlist);
                }
            }
            else
            {
                TrackEvent("TrackIfNotFilesDeleted_Input", inputModel, statusCode.ToString());
            }
        }

      
        public JsonResult ReturnJsonResult<TResult, TModel>(IRequestProviderResult<TResult> result, TModel model)
        {
            JsonResultModel<TResult, TModel> jsonResult = new JsonResultModel<TResult, TModel>();
            if (model != null)
            {
                jsonResult.Model = model;
            }
            jsonResult.StatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), ((int)result.StatusCode).ToString());
            if (result.Success)
            {
                jsonResult.Success = true;
                jsonResult.Result = result.Data; 
            }
            else
            {
                jsonResult.Success = false; 

                foreach (var error in result.Messages)
                {
                    var errorMessages = new List<string>();

                    foreach (var errorMessage in error.Value)
                    {
                        errorMessages.Add(errorMessage);
                    }

                    jsonResult.Errors.Add(new KeyValuePair<string, List<string>>(error.Key, errorMessages));
                }
            }

            return Json(jsonResult);

        }

        public JsonResult ReturnJsonErrorResult<TModel>(ModelStateDictionary modelState, TModel model)
        {
            var jsonResult = new JsonResultModel<dynamic, TModel>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Errors = new List<KeyValuePair<string, List<string>>>(),
                Result = null
            };
            if (model != null)
            {
                jsonResult.Model = model;
            }
            foreach (var error in modelState)
            {
                var errorMessages = new List<string>();
                if (error.Value.Errors.Count > 0)
                {
                    foreach (var value in error.Value.Errors)
                    {
                        errorMessages.Add(value.ErrorMessage);
                    }

                    jsonResult.Errors.Add(new KeyValuePair<string, List<string>>(error.Key, errorMessages));
                }
            }

            return Json(jsonResult);
        }

        public JsonResult ReturnJsonErrorResult<TModel>(string msg, TModel model)
        {
            var jsonResult = new JsonResultModel<dynamic, TModel>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Errors = new List<KeyValuePair<string, List<string>>>
                            {
                                new KeyValuePair<string, List<string>> ("ExceptionError", new List<string> { msg })
                            },
                Result = null,

            };
            if (model != null)
            {
                jsonResult.Model = model;
            }


            return Json(jsonResult);
        }

        public async Task<UploadFileInfo> GenerateFileInfo(IFormFile file)
        {
            MemoryStream stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;
            return new UploadFileInfo
            {
                Stream = stream,
                FileName = file.FileName
            };
        }



        public string GetCurrentDataLang()
        {
            return DataCultureHelper.GetCurrent(Request.Query);
        }


        #region Filter Methods
        public void GetDefaultFiltersList(Filter model, string sortKeyName = "title")
        {
            bool Hasmodel = (model != null) ? true : false;
            int activePageSize = (Hasmodel) ? model.PageSize : 10;

            #region -- page size -------------------------------------
            List<SelectListItem> PageSizes = new List<SelectListItem>()
            {
                 new SelectListItem {  Text = "5", Value = "5" , Selected = activePageSize == 5 },
                 new SelectListItem {  Text = "10", Value = "10" , Selected = activePageSize == 10 },
                 new SelectListItem {  Text = "25", Value = "25" , Selected = activePageSize == 25 },
                 new SelectListItem {  Text = "50", Value = "50" , Selected = activePageSize == 50 },
                 new SelectListItem {  Text = "100", Value = "100" , Selected = activePageSize == 100 },
            };

            ViewBag.pagesizes = PageSizes;
            #endregion

            #region -- Sort List ------------------------------------------
            List<SelectListItem> SortItems = new List<SelectListItem>()
            {

                 new SelectListItem
                { Text = _localizer["title_a_to_z"], Value =  sortKeyName  ,  Selected = model.SortBy ==   sortKeyName   && !model.Desc },
                new SelectListItem
                { Text = _localizer["title_z_to_a"], Value = $"{sortKeyName}_desc" , Selected = model.SortBy == $"{sortKeyName}_desc" && model.Desc },
                new SelectListItem
                { Text = _localizer["newst_first"] ,Value = "date_desc" ,Selected =  model.SortBy == "date" && !model.Desc },
                new SelectListItem
                { Text = _localizer["oldest_first"] ,Value = "date" ,Selected =  model.SortBy == "date" && model.Desc },

            };
            ViewBag.sortList = SortItems;



            #endregion


            #region visibility
            List<SelectListItem> visibility = new List<SelectListItem>()
            {
                 new SelectListItem
                { Text = _localizer["published"] , Value = "1" ,  Selected =  model.Visibility  == 1 },
                  new SelectListItem
                { Text = _localizer["unpublished"] , Value = "0" ,  Selected = model.Visibility  == 0 },
            };
            ViewBag.visibilityList = visibility;
            #endregion
        }


        #endregion

        public void AddModelStateError(Dictionary<string, List<string>> messages)
        {
            foreach (var res in messages)
            {
                foreach (var msg in res.Value)
                {
                    ModelState.AddModelError(res.Key, msg);
                }
            }
        }


    }
}
