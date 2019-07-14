using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Common
{
    public class PublishLookupModel
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
    public class  PublishModel : BasePublishModel
    {
 
    } 

    public class ActiveModel : BasePublishModel
    {

    } 
    public class BasePublishModel
    {
         
        [JsonProperty("id")]
        public Guid Id { get; set; }

         
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }

}
