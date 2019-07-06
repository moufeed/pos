using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTech.Monshaat.POS.Web.Core.Providers.Requests;

namespace TamTech.Monshaat.POS.Web.Services.APIsServices
{
    public class BaseAPIService
    {
        #region Props 
        private readonly IRequestProvider _requestProvider; 
        #endregion


        #region Ctors
        public BaseAPIService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }
        #endregion
    }


    public class DeleteModel<T>
    {
        public DeleteModel(T id)
        {
            Id = id;
        }

        [JsonProperty("id")]
        public T Id { get; set; }
    }
}
