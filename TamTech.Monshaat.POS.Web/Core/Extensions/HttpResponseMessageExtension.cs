using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TamTechSDK.Common.Models.Exceptions;

namespace TamTechSDK.Web.Extensions.remove
{
    public static class HttpResponseMessageExtension
    {
        public static async Task<ExceptionResponse> ExceptionResponse(this HttpResponseMessage httpResponseMessage)
        {
            ExceptionResponse exceptionResponse = new ExceptionResponse();
            string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            try
            {
                exceptionResponse = JsonConvert.DeserializeObject<ExceptionResponse>(responseContent);
            }
            catch (Exception ex)
            {
                ExceptionMessage exceptionMessage = JsonConvert.DeserializeObject<ExceptionMessage>(responseContent);
                exceptionResponse.Message = exceptionMessage.Message;
            }

            return exceptionResponse;
        }

    }


}
