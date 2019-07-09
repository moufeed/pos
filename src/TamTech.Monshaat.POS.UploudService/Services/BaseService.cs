using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.UploadService.Models;

namespace TamTech.Monshaat.POS.UploadService.Services
{
    public class BaseService
    {
        public IResultModel<TResult> ReturnFailure<TResult>(FluentValidation.Results.ValidationResult validationResult)
        {
            IResultModel<TResult> _resultModel = new ResultModel<TResult>
            {
                Success = false,
                StatusCode = StatusCodeEnum.BadRequest,
            };

            foreach (var failure in validationResult.Errors)
            {
                if (failure.ErrorCode == StatusCodeEnum.Locked.ToString())
                {
                    _resultModel.StatusCode = StatusCodeEnum.Locked;
                }
                _resultModel.AddError(failure.PropertyName, failure.ErrorMessage);

            }
            return _resultModel;
        }


        /// <summary>
        ///  A generic method to return result the execution of a process wrapped in a ResultModel model.
        ///  when failure execution of a process return :
        ///                                                 - Success is false.
        ///                                                 - Failure message into model error.
        ///                                                 - Internal Server Error status code.
        ///  when Success execution of a process return :
        ///                                                 - Success is true.
        ///                                                 - result data. 
        ///                                                 - Ok status code                                               
        /// </summary>
        /// <typeparam name="TResultData"></typeparam>
        /// <param name="actionResult"> Resulting from the execution of a process</param>
        /// <param name="data">result data</param>
        /// <returns> ResultModel<TResultData> </returns>
        public IResultModel<TResultData> ReturnProcessResult<TResultData>(bool actionResult, TResultData data)
        {
            IResultModel<TResultData> _resultModel = new ResultModel<TResultData>();
            if (actionResult)
            {
                _resultModel.Success = true;
                _resultModel.StatusCode = StatusCodeEnum.OK;
                _resultModel.Data = data;
            }
            else
            {
                _resultModel.Success = false;
                _resultModel.AddError("Error", $"There was an error while processing. Please try again later!");
                _resultModel.StatusCode = StatusCodeEnum.InternalServerError;
            }
            return _resultModel;
        }

    }
}
