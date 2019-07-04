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
using TamTech.Monshaat.POS.Web.Services.Upload;
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


        private readonly IStringLocalizer<AdminBaseController> _localizer;

        // public readonly IHelperService _helperService; 


        public AdminBaseController(ITelemetryService telemetryClientService, IStringLocalizer<AdminBaseController> localizer)
            : base(telemetryClientService)
        {
            //  _helperService = helperService;
            ViewData["Area"] = "Admin";
            _localizer = localizer;
        }




        private const bool _disableSuccessMode = false;
        private const string _successMsg = "The process has successfully.";
        private const string _errorMsg = "General Error!!";
        private const string _expMsg = "There was an error executing the process!";
        public dynamic SuccessModel { get { return TempData["SuccessModel"]; } set { TempData["SuccessModel"] = value; } }


        public void CheckSuccessModel()
        {
            var _successModel = SuccessModel;
            ViewData["SuccessResultMode"] = !string.IsNullOrEmpty(_successModel);
            ViewData["SuccessModel"] = _successModel;
            SuccessModel = null;
        }
        public void ShowSuccessModel(string msg)
        {
            ViewData["SuccessModel"] = msg;
        }
        public void AddErrorModel(string key = "Error", string msg = "General Error!!")
        {
            ModelState.AddModelError(key, msg);
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


        public void HandelResult(dynamic result,
                                                bool disableSuccessMode = _disableSuccessMode,
                                                string successMsg = _successMsg,
                                                string errorMsg = _errorMsg,
                                                string expMsg = _expMsg)
        {
            ModelState.Clear();
            //ViewData["MessageInfoState"] = 
            ViewData["SuccessResultMode"] = false;
            ViewData["ErrorResultMode"] = false;
            ViewData["ExpResultMode"] = false;
            ViewData["WarningResultMode"] = false;
            ViewData["InfoResultMode"] = false;

            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                    {
                        SuccessModel = successMsg;
                        ModelState.Clear();
                        ViewData["SuccessResultMode"] = !disableSuccessMode;
                        break;
                    }
                case HttpStatusCode.BadRequest:
                    {
                        if (result.Messages != null)
                        {
                            foreach (var item in result.Messages)
                            {
                                foreach (var msg in item.Value)
                                {
                                    AddErrorModel(item.Key, msg);
                                }
                            }
                        }
                        else AddErrorModel();
                        ViewData["ErrorResultMode"] = true;
                        break;
                    }
                case HttpStatusCode.InternalServerError:
                    {
                        AddErrorModel("Internal Server Error", result.Exception.Message);
                        ViewData["ExpResultMode"] = true;
                        break;
                    }
                case HttpStatusCode.Unauthorized:
                    {
                        AddErrorModel("Unauthorized", "Unauthorized!");
                        ViewData["ErrorResultMode"] = true;
                        break;
                    }
                case HttpStatusCode.NotFound:
                    {
                        AddErrorModel("Not Found", "Not Found!");
                        ViewData["ErrorResultMode"] = true;
                        break;
                    }
                case HttpStatusCode.Created:
                    {
                        if (successMsg == _successMsg)
                            SuccessModel = "The item creation was successfully.";
                        else
                            SuccessModel = successMsg;
                        ViewData["SuccessResultMode"] = true;
                        ModelState.Clear();
                        break;
                    }
                case HttpStatusCode.NotModified:
                    {
                        SuccessModel = "Not Modified.";
                        ViewData["WarningResultMode"] = true;
                        ModelState.Clear();
                        break;
                    }

                case HttpStatusCode.NoContent:
                    {
                        SuccessModel = "No Content.";
                        ViewData["InfoResultMode"] = true;
                        ModelState.Clear();
                        break;
                    }
                default:
                    {
                        AddErrorModel(result.StatusCode.ToString(), result.StatusCode.ToString());
                        ViewData["WarningResultMode"] = true;
                        break;
                    }

            }

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

        //public void TrackIfNotFilesDeleted( bool success,
        //                                          HttpStatusCode statusCode, 
        //                                          DeleteFilesModelResult resultModel,
        //                                          DeleteFilesInputModel inputModel )
        //      {
        //          if (success)
        //          {
        //              var errorlist = resultModel.Results.Where(item => item.Result == DeleteResult.NotDeleted);
        //              if (errorlist != null && errorlist.Count() > 0)
        //              {
        //                  TrackEvent("TrackIfNotFilesDeleted_Result", errorlist);
        //              }
        //          }
        //          else
        //          {
        //              TrackEvent("TrackIfNotFilesDeleted_Input",  inputModel.DeletedFiles, statusCode.ToString());
        //          }
        //      }


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
            if (result.Success)
            {
                jsonResult.Success = true;
                jsonResult.Result = result.Data;
                jsonResult.StatusCode = result.StatusCode;
            }
            else
            {
                jsonResult.Success = false;
                jsonResult.StatusCode = result.StatusCode;

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


        public JsonResult ReturnJson<TResult, TModel>(IRequestProviderResult<TResult> result, TModel model)
        {
            JsonResultModel<TResult, TModel> jsonResult = new JsonResultModel<TResult, TModel>();
            if (model != null)
            {
                jsonResult.Model = model;
            }
            if (result.Success)
            {
                jsonResult.Success = true;
                jsonResult.Result = result.Data;
                jsonResult.StatusCode = result.StatusCode;
            }
            else
            {
                jsonResult.Success = false;
                jsonResult.StatusCode = result.StatusCode;

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

        public async Task<List<UploadFileModel>> GenerateListFilesInfo(IFormFileCollection files, FileTypesEnum type)
        {
            List<UploadFileModel> Files = new List<UploadFileModel>();
            foreach (var file in files)
            {
                Files.Add(new UploadFileModel
                {
                    Type = type,
                    FileInfo = await GenerateFileInfo(file)
                });
            }
            return Files;
        }

        public async Task<List<UploadFileModel>> GenerateListFilesInfo(IFormFileCollection files, Dictionary<string, FileTypesEnum> types, FileTypesEnum defaultType = FileTypesEnum.General)
        {
            List<UploadFileModel> Files = new List<UploadFileModel>();
            foreach (var file in files)
            {
                var t = types.ContainsKey(file.Name) ? types[file.Name] : defaultType;
                Files.Add(new UploadFileModel
                {

                    Type = t,
                    FileInfo = await GenerateFileInfo(file)
                });
            }
            return Files;
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
