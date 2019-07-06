using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Telemetry;
using TamTech.Monshaat.POS.Web.Core.Extensions;
using Microsoft.AspNetCore.Authorization;
using TamTech.Monshaat.POS.Web.Services.Upload.Models; 
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TamTech.Monshaat.POS.Web.Models.Dtos.Sort;
using TamTech.Monshaat.POS.Web.Models.VMs.Shared.Filters;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;

namespace TamTechSDK.Web.Controllers
{

    public class BaseController : Controller
    {
        #region Props 
      //  public readonly ITelemetryClientService _telemetryClientService;
        #endregion

        #region Ctors
        public BaseController(ITelemetryService telemetryClientService)
        {
         //   _telemetryClientService = telemetryClientService;
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
