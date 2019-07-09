using System;
using System.Collections.Generic;
using System.Text; 

namespace TamTech.Monshaat.POS.UploadService.Models
{
    public class ResultModel<TResult> : IResultModel<TResult>
    {
        public TResult Data { get; set; } 

        public bool Success { get; set; } = true;

        public Dictionary<string, List<string>> Messages { get; set; }

        public StatusCodeEnum StatusCode { get; set; }

        public Dictionary<string, object> HeaderParams { get; set; }
         
        public void AddError(string key, string errorMessage)
        {
            if (Messages == null)
            {
                Messages = new Dictionary<string, List<string>> { { key, new List<string> { errorMessage } } };
                return;
            }
            if (Messages.ContainsKey(key))
            {
                List<string> value = Messages[key];
                value.Add(errorMessage);
                Messages[key] = value;
            }
            else
            {
                Messages.Add(key, new List<string> { errorMessage });
            }
        }

        public void AddParamToHeader(string key, object value)
        {
            if (HeaderParams == null)
            {
                HeaderParams = new Dictionary<string, object> { { key, value } };
                return;
            } 
            else
            {
                HeaderParams.Add(key, value);
            }
        }
    }

    
}
