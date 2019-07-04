using System;
using System.Collections.Generic;
using System.Text;
using TamTechSDK.Common.Providers.Requests.Models;

namespace TamTechSDK.Common.Services
{
    public class CommonBaseService
    {
 
        public TResult GetDataResult<TResult>(IRequestProviderResult<TResult> model)
        {
            if (model.Success && model.Data != null)
            {
                return model.Data;
            } 
            else
            {
                // >>>  Loge 
            }

            return default(TResult);
        }
    }
}
