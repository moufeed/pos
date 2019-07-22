using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.SDK.Core.Telemetry;
using TamTech.Monshaat.POS.Web.SDK.Core.Extensions;
using Microsoft.AspNetCore.Authorization;
using TamTech.Monshaat.POS.Web.SDK.Services.Upload.Models; 
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TamTech.Monshaat.POS.Web.SDK.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.SDK.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.SDK.Core.Providers.Requests.Models;
using Microsoft.Extensions.Localization;
namespace TamTechSDK.Web.Controllers
{

    public class BaseController : Controller
    {
        #region Props 
       
        private readonly IStringLocalizer<BaseController> _localizer;

        private const bool _disableSuccessMode = false;
        private const string _successMsg = "The process has successfully.";
        private const string _errorMsg = "General Error!!";
        private const string _expMsg = "There was an error executing the process!";
        #endregion

        #region Ctors
        public BaseController(ITelemetryService telemetryClientService , IStringLocalizer<BaseController> localizer)
        {
            //   _telemetryClientService = telemetryClientService;
            _localizer = localizer;
        }
        #endregion 

        #region Methodes

        public bool VerifySucceed<T>(IRequestProviderResult<T> result)
        {
            return result != null && result.Success && result.Data != null;
        }

        public virtual void TrackException(Exception exc)
        {
            //
        }


        public void TrackIfNotFilesDeleted(bool success,
                                            HttpStatusCode statusCode,
                                            DeleteFilesModelResult resultModel,
                                            DeleteFilesInputModel inputModel)
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
                TrackEvent("TrackIfNotFilesDeleted_Input", inputModel.DeletedFiles, statusCode.ToString());
            }
        }

        public void TrackEvent(string name, dynamic model, string statusCode = null)
        {

        //

        }

        public void TrackEvent(string name, ModelStateDictionary modelState, dynamic model = null)
        { 
          // 
        }


        public RedirectToActionResult RedirectToNotFound(object pName)
        {
            return RedirectToAction("HandelError", "Error", new { statusCode = "404", pageName = pName });
        }
        public RedirectToActionResult RedirectToException(string message)
        {
            return RedirectToAction("Exception", "Error", new { msg = message });
        }


        public Uri GetAbsoluteUri()
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = this.Request.Scheme;
            uriBuilder.Host = this.Request.Host.Host;
            uriBuilder.Path = this.Request.Path.ToString();
            uriBuilder.Query = this.Request.QueryString.ToString();
            return uriBuilder.Uri;
        }
        public Uri GetHostUri()
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = this.Request.Scheme;
            uriBuilder.Host = this.Request.Host.Host;
            return uriBuilder.Uri;
        }
        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time</param>  
        public void SetCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMinutes(10);

            Response.Cookies.Append(key, value, option);
        }

        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        public void RemoveCookie(string key)
        {
            Response.Cookies.Delete(key);
        }
        #endregion


        public void AddErrorModel(string key = "Error", string msg = "General Error!!")
        {
            ModelState.AddModelError(key, msg);
        }


        
        public dynamic SuccessModel { get { return TempData["SuccessModel"]; } set { TempData["SuccessModel"] = value; } }

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
                        AddErrorModel("Internal_Server_Error", _localizer["Internal_Server_Error_message"]); //result.Exception.Message
                        ViewData["ExpResultMode"] = true;
                        break;
                    }
                case HttpStatusCode.Unauthorized:
                    {
                        AddErrorModel("Unauthorized" , _localizer["Unauthorized_msg"]);
                        ViewData["ErrorResultMode"] = true;
                        break;
                    }
                case HttpStatusCode.NotFound:
                    {
                        AddErrorModel("not_found" , _localizer["not_found_msg"]);
                        ViewData["ErrorResultMode"] = true;
                        break;
                    }
                case HttpStatusCode.Created:
                    {
                        if (successMsg == _successMsg)
                            SuccessModel = "The item creation was successfully.";
                        else
                            SuccessModel = _localizer[successMsg];
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

        #region Filter Methods
        public SortingModel CreateSortingModel(string sortKey)
        {
            string SortBy = string.Empty;
            bool Desc = true;
            if (string.IsNullOrWhiteSpace(sortKey))
            {
                return new SortingModel();
            }

            switch (sortKey)
            {
                case "date":
                case "title":
                case "name":
                case "fullname":
                    Desc = false;
                    SortBy = sortKey;
                    break;

                case "name_desc":
                    SortBy = "name";
                    Desc = true;
                    break;

                case "fullname_desc":
                    SortBy = "fullname";
                    Desc = true;
                    break;

                case "title_desc":
                    SortBy = "title";
                    Desc = true;
                    break;

                case "date_desc":
                    SortBy = "date";
                    Desc = true;
                    break;

                default:
                    break;
            }

            return new SortingModel()
            {
                SortBy = SortBy,
                Descending = Desc
            };
        }



        public Dictionary<string, object> GenrateSearchParams(Filter model)
        {

            Dictionary<string, object> searchParams = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(model.Title))
            {
                searchParams.Add("Title", model.Title);
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                searchParams.Add("Name", model.Name);
            }
            if (!string.IsNullOrEmpty(model.FullName))
            {
                searchParams.Add("FullName", model.FullName);
            }
            if (!string.IsNullOrEmpty(model.Section))
            {
                searchParams.Add("Section", model.Section);
            }
            if (!string.IsNullOrEmpty(model.AuthorName))
            {
                searchParams.Add("AuthorName", model.AuthorName);
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                searchParams.Add("Email", model.Email);
            }
            if (!string.IsNullOrEmpty(model.Search))
            {
                searchParams.Add("Search", model.Search);
            }
            if (!string.IsNullOrEmpty(model.SectorSlug))
            {
                searchParams.Add("SectorSlug", model.SectorSlug);
            }
            if (!string.IsNullOrEmpty(model.valIds))
            {
                searchParams.Add("ValIds", model.valIds);
            }
            if (!string.IsNullOrEmpty(model.TypeIds))
            {
                searchParams.Add("TypeIds", model.TypeIds);
            }

            if (model.SectionId != null)
            {
                searchParams.Add("SectionId", model.SectionId);
            }
            if (model.CityId != null)
            {
                searchParams.Add("CityId", model.CityId);
            }
            if (model.StatusId != null)
            {
                searchParams.Add("StatusId", model.StatusId);
            }
            if (model.Visibility != null)
            {
                searchParams.Add("Publish", model.Visibility);
            }
            if (model.Type != null)
            {
                searchParams.Add("Type", model.Type);
            }
            if (model.ParentId != null)
            {
                searchParams.Add("ParentId", model.ParentId);
            }
            if (model.Rating != null)
            {
                searchParams.Add("Rate", model.Rating);
            }
            if (model.TypeId != null)
            {
                searchParams.Add("TypeId", model.TypeId);
            }
            if (model.SectorId != null)
            {
                searchParams.Add("SectorId", model.SectorId);
            }
            if (model.AttId != 0)
            {
                searchParams.Add("AttId", model.AttId);
            }

            return searchParams;
        }
        #endregion
    }
}
