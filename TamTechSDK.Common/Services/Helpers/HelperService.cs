using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace TamTechSDK.Common.Services.Helpers
{
    public class HelperService : IHelperService
    {
        //#region properties  
        //public readonly JsonSerializerSettings _serializerSettings;
        //#endregion

        //#region Constructors 
        //public HelperService( )
        //{
        //    _serializerSettings = new JsonSerializerSettings
        //    {
        //        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        //        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        //        NullValueHandling = NullValueHandling.Ignore
        //    };
        //    _serializerSettings.Converters.Add(new StringEnumConverter());  
        //}
        //#endregion

        #region Methods  
        public bool IsNullOrDefault<TEntity>(TEntity model)
        {
            return true;  //  return model == null || (dynamic)model == default(TEntity) ? true : false;
        }

        //public bool IsNullOrEmpty(Guid id)
        //{
        //    if (id == null || id == Guid.Empty)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public TResult DeserializeFromObject<TResult>(dynamic inputObject)
        //{
        //    string serialized = JsonConvert.SerializeObject(inputObject);
        //    var handledResult = JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings);
        //    return handledResult;
        //}
        #endregion
    }
}
