using System;
using System.Collections.Generic;
using System.Text;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests.Models;

namespace TamTech.Monshaat.POS.Web.Services
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
