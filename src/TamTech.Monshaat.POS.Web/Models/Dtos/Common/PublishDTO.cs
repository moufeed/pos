using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TamTech.Monshaat.POS.Web.Models.Dtos.Common
{
    public class PublishDTO
    {

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("intid")]
        public int IntId { get; set; }
    }

    public class ActiveModel : PublishDTO
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
