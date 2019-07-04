using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;

namespace TamTech.Monshaat.POS.Web.DirectBackendServices
{
    public class BaseDirectService
    {

        #region Props  
        public readonly string _lang;
        public readonly string _culture;
        #endregion


        #region Ctors
        public BaseDirectService()
        {
            _lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            _culture = CultureInfo.CurrentCulture.Name;
        }
        #endregion

        #region Utilities

        public HttpStatusCode MapToHttpStatusCode(TamTech.ContentService.Enums.StatusCodeEnum code)
        {


            switch (code)
            {
                case TamTech.ContentService.Enums.StatusCodeEnum.Continue:
                    return HttpStatusCode.Continue;
                case TamTech.ContentService.Enums.StatusCodeEnum.OK:
                    return HttpStatusCode.OK;
                case TamTech.ContentService.Enums.StatusCodeEnum.Redirect:
                    return HttpStatusCode.Redirect;
                case TamTech.ContentService.Enums.StatusCodeEnum.BadRequest:
                    return HttpStatusCode.BadRequest;
                case TamTech.ContentService.Enums.StatusCodeEnum.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case TamTech.ContentService.Enums.StatusCodeEnum.PaymentRequired:
                    return HttpStatusCode.PaymentRequired;
                case TamTech.ContentService.Enums.StatusCodeEnum.Forbidden:
                    return HttpStatusCode.Forbidden;
                case TamTech.ContentService.Enums.StatusCodeEnum.NotFound:
                    return HttpStatusCode.NotFound;
                case TamTech.ContentService.Enums.StatusCodeEnum.RequestTimeout:
                    return HttpStatusCode.RequestTimeout;
                case TamTech.ContentService.Enums.StatusCodeEnum.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case TamTech.ContentService.Enums.StatusCodeEnum.NotImplemented:
                    return HttpStatusCode.NotImplemented;
                case TamTech.ContentService.Enums.StatusCodeEnum.BadGateway:
                    return HttpStatusCode.BadGateway;
                case TamTech.ContentService.Enums.StatusCodeEnum.ServiceUnavailable:
                    return HttpStatusCode.ServiceUnavailable;
                case TamTech.ContentService.Enums.StatusCodeEnum.GatewayTimeout:
                    return HttpStatusCode.GatewayTimeout;
            }


            return HttpStatusCode.BadRequest;
        }


        public IRequestProviderResult<TResult> MapRequestProviderResult<TResult>(
           TamTech.ContentService.Core.Domain.Models.Results.IReturnResultModel<TResult> inputResult)
        {
            IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>();
            _resultModel.Success = inputResult.Success;
            _resultModel.StatusCode = (System.Net.HttpStatusCode)((int)inputResult.StatusCode);
            _resultModel.Data = inputResult.Data;
            _resultModel.Messages = _resultModel.Success ? null : _resultModel.Messages = new Dictionary<string, List<string>>();
            foreach (KeyValuePair<string, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry> error in inputResult.ModelState)
            {
                List<string> errorMessages = new List<string>();
                if (error.Value.Errors.Count > 0)
                {
                    foreach (Microsoft.AspNetCore.Mvc.ModelBinding.ModelError value in error.Value.Errors)
                    {
                        errorMessages.Add(value.ErrorMessage);
                    }

                    _resultModel.Messages.Add(error.Key, errorMessages);
                }
            }
            return _resultModel;
        }

        public IRequestProviderResult<TResult> MapRequestProviderResult<TResult>(
           TamTechBackendSDK.IdentityService.Models.IReturnResultModel<TResult> inputResult)
        {
            IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>();
            _resultModel.Success = inputResult.Success;
            _resultModel.StatusCode = inputResult.StatusCode;
            _resultModel.Data = inputResult.Data;
            _resultModel.Messages = _resultModel.Success ? null : _resultModel.Messages = new Dictionary<string, List<string>>();
            foreach (KeyValuePair<string, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry> error in inputResult.ModelState)
            {
                List<string> errorMessages = new List<string>();
                if (error.Value.Errors.Count > 0)
                {
                    foreach (Microsoft.AspNetCore.Mvc.ModelBinding.ModelError value in error.Value.Errors)
                    {
                        errorMessages.Add(value.ErrorMessage);
                    }

                    _resultModel.Messages.Add(error.Key, errorMessages);
                }
            }
            return _resultModel;
        }

        public IRequestProviderResult<TResult> MapRequestProviderResult<TResult>(
         TamTech.ContentService.Core.Domain.Models.IResultModel<TResult> inputResult
         )
        {

            IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>()
            {
                Success = inputResult.Success,
                Header = inputResult.HeaderParams,
                Data = inputResult.Data,
                Messages = inputResult.Success ? null : new Dictionary<string, List<string>>(),
                StatusCode = MapToHttpStatusCode(inputResult.StatusCode)
            };

            if (!inputResult.Success)
            {
                foreach (KeyValuePair<string, List<string>> error in inputResult.Messages)
                {
                    List<string> errorMessages = new List<string>();

                    if (error.Value.Count > 0)
                    {
                        foreach (var value in error.Value)
                        {
                            errorMessages.Add(value);
                        }
                        _resultModel.Messages.Add(error.Key, errorMessages);
                    }
                }
            }

            return _resultModel;
        }

        //public IRequestProviderResult<TResult> MapRequestResult<TResult>(
        //    TamTech.ContentService.Core.Domain.Models.IResultModel<TResult> inputResult
        //    )
        //{

        //    IRequestProviderResult<TResult> result = new ResultModel<TResult>()
        //    {
        //        Success = inputResult.Success,
        //        HeaderParams=inputResult.HeaderParams,
        //        Data = inputResult.Data,
        //        Messages = inputResult.Success ? null : new Dictionary<string, List<string>>(),
        //        StatusCode = MapToHttpStatusCode(inputResult.StatusCode)
        //    };

        //    if (!inputResult.Success)
        //    {
        //        foreach (KeyValuePair<string, List<string>> error in inputResult.Messages)
        //        {
        //            List<string> errorMessages = new List<string>();

        //            if (error.Value.Count > 0)
        //            {
        //                foreach (var value in error.Value)
        //                {
        //                    errorMessages.Add(value);
        //                }
        //                result.Messages.Add(error.Key, errorMessages);
        //            }
        //        }
        //    }

        //    return result;
        //}


        public IRequestProviderResult<TResult> ReturnResult<TResult>(TResult data, bool Success = true, System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.OK, Dictionary<string, List<string>> Messages = null)
        {
            IRequestProviderResult<TResult> _resultModel = new RequestProviderResult<TResult>();
            _resultModel.Success = Success;
            _resultModel.StatusCode = statusCode;
            _resultModel.Data = data;

            if (!Success && Messages != null)
            {
                foreach (KeyValuePair<string, List<string>> error in Messages)
                {
                    List<string> errorMessages = new List<string>();

                    if (error.Value.Count > 0)
                    {
                        foreach (var value in error.Value)
                        {
                            errorMessages.Add(value);
                        }
                        _resultModel.Messages.Add(error.Key, errorMessages);
                    }
                }
            }
            return _resultModel;
        }


        public IRequestProviderResult<TOutputResult> ReturnResult<TOutputResult, TInputResult>(TamTech.ContentService.Core.Domain.Models.Results.IReturnResultModel<TInputResult> inputResult, TOutputResult data)
        {
            IRequestProviderResult<TOutputResult> _resultModel = new RequestProviderResult<TOutputResult>();
            _resultModel.Messages = inputResult.Success ? null : _resultModel.Messages = new Dictionary<string, List<string>>();
            foreach (KeyValuePair<string, Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry> error in inputResult.ModelState)
            {
                List<string> errorMessages = new List<string>();
                if (error.Value.Errors.Count > 0)
                {
                    foreach (Microsoft.AspNetCore.Mvc.ModelBinding.ModelError value in error.Value.Errors)
                    {
                        errorMessages.Add(value.ErrorMessage);
                    }

                    _resultModel.Messages.Add(error.Key, errorMessages);
                }
            }
            _resultModel.Success = inputResult.Success;
            _resultModel.StatusCode = (System.Net.HttpStatusCode)((int)inputResult.StatusCode);
            _resultModel.Data = data;
            return _resultModel;
        }


        #region Deserialize
        public TResult DeserializeFromObject<TResult>(dynamic inputObject)
        {
            string serialized = JsonConvert.SerializeObject(inputObject);
            TResult handledResult = JsonConvert.DeserializeObject<TResult>(serialized);
            return handledResult;
        }
        #endregion

        #endregion


    }
}
